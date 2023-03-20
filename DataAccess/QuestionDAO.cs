using BusinessObjects;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class QuestionDAO
    {
        public QuestionAndAnswerDTO AddQuestion(int userId, QuestionAndAnswerDTO questionAndAnswer)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                        var question = new Question();

                            /*UserId
                            Text
                            IsMultiChoice
                            Lever
                            Type
                            User*/


                        question.UserId = userId;
                        question.Text = questionAndAnswer.Text;
                        var dem = 0;
                        foreach (var item2 in questionAndAnswer.Answers)
                            {
                        var answ = context.Answers.FirstOrDefault(o => o.AnswerId == item2.AnswerId);
                                if(answ.IsCorrect == true)
                                {
                                    dem += 1;
                                }
                                
                            }
                        if (dem >= 2)
                        {
                            question.IsMultiChoice = true;
                        }
                        else
                        {
                            question.IsMultiChoice = false;
                        }

                        question.Lever = questionAndAnswer.Lever;
                        question.Type = questionAndAnswer.Type;
                        context.Questions.Add(question);
                        context.SaveChanges();
                        var temp = question;
                        foreach (var item2 in questionAndAnswer.Answers)
                        {
                            var answer = new Answer();
                            answer.QuestionId = temp.QuestionId;
                            answer.AnswerText = item2.AnswerText;
                            answer.IsCorrect = item2.IsCorrect;
                            context.Answers.Add(answer);
                            context.SaveChanges();
                        }
                    questionAndAnswer.IsMultiChoice = question.IsMultiChoice;

                    }
                      return questionAndAnswer;
              
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<QuestionAndAnswerDTO> GetQuestionsByUserId(int userId)
        {
            try
            {         
                using (var context = new MyDbContext())
                {
                    List<QuestionAndAnswerDTO> questionAndAnswers = new List<QuestionAndAnswerDTO>();
                    List<Question> questions = context.Questions.Where(o=>o.UserId==userId).ToList();
                    foreach (var item in questions)
                    {
                        List<Answer> answers = context.Answers.Where(o => o.QuestionId == item.QuestionId).ToList();
                        List<AnswerDTO> answerDTOs = new List<AnswerDTO>();
                        foreach (var answer in answers)
                        {
                            var answerDTO = new AnswerDTO();
                            answerDTO.AnswerId = answer.AnswerId;
                            answerDTO.AnswerText = answer.AnswerText;
                            answerDTOs.Add(answerDTO);
                        }
                        var questionAndAnswer = new QuestionAndAnswerDTO();
                        questionAndAnswer.QuestionId = item.QuestionId;
                        questionAndAnswer.Text = item.Text;
                        questionAndAnswer.IsMultiChoice = item.IsMultiChoice;
                        questionAndAnswer.Lever = item.Lever;
                        questionAndAnswer.Type = item.Type;
                        questionAndAnswer.Answers = answerDTOs;
                        questionAndAnswers.Add(questionAndAnswer);
                    }
                    return questionAndAnswers;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TestInforDTO GetQuestionsByAccessKey(string accessKey)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    TestInforDTO testInfor = new TestInforDTO();
                    Section section = context.Sections.FirstOrDefault(o => o.AccessKey == accessKey);
                    Paper paper = context.Papers.FirstOrDefault(o => o.PaperId == section.PaperId);
                    List<QuestionAndAnswerDTO> questionAndAnswerDTOs = new List<QuestionAndAnswerDTO>();
                    List<PaperQuestion> paperQuestions = context.PaperQuestions.Where(o => o.PaperId == paper.PaperId).ToList();
                    testInfor.SectionId = section.SectionId;
                    testInfor.TimeLimit = section.TimeLimit;
                    testInfor.AccessKey = section.AccessKey;
                    testInfor.ActivatedAt = section.ActivatedAt;
                    foreach (var item in paperQuestions)
                    {
                        QuestionAndAnswerDTO questionAndAnswer = new QuestionAndAnswerDTO();
                        Question question = context.Questions.FirstOrDefault(o => o.QuestionId == item.QuestionId);
                        questionAndAnswer.Text = question.Text;
                        questionAndAnswer.QuestionId = question.QuestionId;
                        questionAndAnswer.IsMultiChoice = question.IsMultiChoice;
                        List<Answer> answers = context.Answers.Where(o=>o.QuestionId == item.QuestionId).ToList();
                        List<AnswerDTO> answerDTOs = new List<AnswerDTO>();
                        foreach (var answer in answers)
                        {
                            AnswerDTO answerDTO = new AnswerDTO();
                            answerDTO.AnswerId = answer.AnswerId;

                            answerDTO.AnswerText = answer.AnswerText;
                            answerDTOs.Add(answerDTO);
                        }
                        questionAndAnswer.Answers = answerDTOs;
                        questionAndAnswerDTOs.Add(questionAndAnswer);                        
                    }
                    testInfor.questionAndAnswerDTOs = questionAndAnswerDTOs;
                    return testInfor;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<QuestionAndAnswerDTO> GetQuestionsBySearch(int userId,string searchKey)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    List<QuestionAndAnswerDTO> questionAndAnswers = new List<QuestionAndAnswerDTO>();
                    List<Question> questions = context.Questions.Where(o => o.UserId == userId).Where(o=>o.Text.Contains(searchKey)).ToList();
                    foreach (var item in questions)
                    {
                        List<Answer> answers = context.Answers.Where(o => o.QuestionId == item.QuestionId).ToList();
                        List<AnswerDTO> answerDTOs = new List<AnswerDTO>();
                        foreach (var answer in answers)
                        {
                            var answerDTO = new AnswerDTO();
                            answerDTO.AnswerId = answer.AnswerId;
                            answerDTO.AnswerText = answer.AnswerText;
                            answerDTOs.Add(answerDTO);
                        }
                        var questionAndAnswer = new QuestionAndAnswerDTO();
                        questionAndAnswer.QuestionId = item.QuestionId;
                        questionAndAnswer.Text = item.Text;
                        questionAndAnswer.IsMultiChoice = item.IsMultiChoice;
                        questionAndAnswer.Lever = item.Lever;
                        questionAndAnswer.Type = item.Type;
                        questionAndAnswer.Answers = answerDTOs;
                        questionAndAnswers.Add(questionAndAnswer);
                    }
                    return questionAndAnswers;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public List<QuestionAndAnswerDTO> GetQuestionsByPaging(int userId, int pageNumber,int pageSize)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    List<QuestionAndAnswerDTO> questionAndAnswers = new List<QuestionAndAnswerDTO>();
                    List<Question> questions = context.Questions.Where(o => o.UserId == userId).Skip((pageNumber - 1) * pageSize)
                                                .Take(pageSize)
                                                .ToList(); ;
                    foreach (var item in questions)
                    {
                        List<Answer> answers = context.Answers.Where(o => o.QuestionId == item.QuestionId).ToList();
                        List<AnswerDTO> answerDTOs = new List<AnswerDTO>();
                        foreach (var answer in answers)
                        {
                            var answerDTO = new AnswerDTO();
                            answerDTO.AnswerId = answer.AnswerId;
                            answerDTO.AnswerText = answer.AnswerText;
                            answerDTO.IsCorrect = answer.IsCorrect;
                            answerDTOs.Add(answerDTO);
                        }
                        var questionAndAnswer = new QuestionAndAnswerDTO();
                        questionAndAnswer.QuestionId = item.QuestionId;
                        questionAndAnswer.Text = item.Text;
                        questionAndAnswer.IsMultiChoice = item.IsMultiChoice;
                        questionAndAnswer.Lever = item.Lever;
                        questionAndAnswer.Type = item.Type;
                        questionAndAnswer.Answers = answerDTOs;
                        questionAndAnswers.Add(questionAndAnswer);
                    }
                    return questionAndAnswers;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
