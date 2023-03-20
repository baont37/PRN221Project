using BusinessObjects;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PaperDAO
    {
        public PaperAndPaperQuestionDTO AddPaper(int userId, PaperAndPaperQuestionDTO paperAndPaperQuestion)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var paper = new Paper();
                    paper.UserId = userId;
                    paper.CreatedAt = DateTime.Now;
                    paper.Name = paperAndPaperQuestion.Name;
                    context.Papers.Add(paper);
                    context.SaveChanges();
                    var temp = paper;
                    foreach (var item in paperAndPaperQuestion.PaperQuestions)
                    {
                        PaperQuestion paperQuestion = new PaperQuestion();
                        paperQuestion.PaperId = temp.PaperId;
                        paperQuestion.QuestionId = item.QuestionId;
                        context.PaperQuestions.Add(paperQuestion);
                        context.SaveChanges();
                    }
                }
                return paperAndPaperQuestion;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public List<PaperAndPaperQuestionDTO> GetPaperAndPaperQuestionsByUserId(int userId)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    List<PaperAndPaperQuestionDTO> paperAndPaperQuestions = new List<PaperAndPaperQuestionDTO>();
                    List<Paper> papers = context.Papers.Where(o => o.UserId == userId).ToList();
                    foreach (var item in papers)
                    {
                        List<PaperQuestion> paperQuestions = context.PaperQuestions.Where(o => o.PaperId == item.PaperId).ToList();
                        List<PaperQuestionDTO> paperQuestionDTOs = new List<PaperQuestionDTO>();
                        foreach (var paperQuestion in paperQuestions)
                        {
                            var paperQuestionDTO = new PaperQuestionDTO();
                            paperQuestionDTO.QuestionId = paperQuestion.QuestionId;
                            paperQuestionDTOs.Add(paperQuestionDTO);
                        }
                        var paperAndPaperQuestion = new PaperAndPaperQuestionDTO();
                        paperAndPaperQuestion.PaperId = item.PaperId;
                        paperAndPaperQuestion.Name = item.Name;
                        paperAndPaperQuestion.CreatedAt = item.CreatedAt;
                        paperAndPaperQuestion.UserId = item.UserId;
                        paperAndPaperQuestion.PaperQuestions = paperQuestionDTOs;
                        paperAndPaperQuestions.Add(paperAndPaperQuestion);
                    }
                    return paperAndPaperQuestions;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<PaperAndPaperQuestionDTO> GetPaperAndPaperQuestionsBySearch(int userId,string searchKey)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    List<PaperAndPaperQuestionDTO> paperAndPaperQuestions = new List<PaperAndPaperQuestionDTO>();
                    List<Paper> papers = context.Papers.Where(o => o.UserId == userId).Where(o => o.Name.Contains(searchKey)).ToList();
                    foreach (var item in papers)
                    {
                        List<PaperQuestion> paperQuestions = context.PaperQuestions.Where(o => o.PaperId == item.PaperId).ToList();
                        List<PaperQuestionDTO> paperQuestionDTOs = new List<PaperQuestionDTO>();
                        foreach (var paperQuestion in paperQuestions)
                        {
                            var paperQuestionDTO = new PaperQuestionDTO();
                            paperQuestionDTO.QuestionId = paperQuestion.QuestionId;
                            paperQuestionDTOs.Add(paperQuestionDTO);
                        }
                        var paperAndPaperQuestion = new PaperAndPaperQuestionDTO();
                        paperAndPaperQuestion.PaperId = item.PaperId;
                        paperAndPaperQuestion.Name = item.Name;
                        paperAndPaperQuestion.CreatedAt = item.CreatedAt;
                        paperAndPaperQuestion.UserId = item.UserId;
                        paperAndPaperQuestion.PaperQuestions = paperQuestionDTOs;
                        paperAndPaperQuestions.Add(paperAndPaperQuestion);
                    }
                    return paperAndPaperQuestions;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<PaperAndPaperQuestionDTO> GetPaperAndPaperQuestionsByPaging(int userId, int pageNumber, int pageSize)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    List<PaperAndPaperQuestionDTO> paperAndPaperQuestions = new List<PaperAndPaperQuestionDTO>();
                    List<Paper> papers = context.Papers.Where(o => o.UserId == userId).Skip((pageNumber - 1) * pageSize)
                                                .Take(pageSize)
                                                .ToList(); 
                    foreach (var item in papers)
                    {
                        List<PaperQuestion> paperQuestions = context.PaperQuestions.Where(o => o.PaperId == item.PaperId).ToList();
                        List<PaperQuestionDTO> paperQuestionDTOs = new List<PaperQuestionDTO>();
                        foreach (var paperQuestion in paperQuestions)
                        {
                            var paperQuestionDTO = new PaperQuestionDTO();
                            paperQuestionDTO.QuestionId = paperQuestion.QuestionId;
                            paperQuestionDTOs.Add(paperQuestionDTO);
                        }
                        var paperAndPaperQuestion = new PaperAndPaperQuestionDTO();
                        paperAndPaperQuestion.PaperId = item.PaperId;
                        paperAndPaperQuestion.Name = item.Name;
                        paperAndPaperQuestion.CreatedAt = item.CreatedAt;
                        paperAndPaperQuestion.UserId = item.UserId;
                        paperAndPaperQuestion.PaperQuestions = paperQuestionDTOs;
                        paperAndPaperQuestions.Add(paperAndPaperQuestion);
                    }
                    return paperAndPaperQuestions;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
