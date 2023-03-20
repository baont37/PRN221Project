using BusinessObjects;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class GradeDAO
    {
        public UserAnswerTest Grade(int userId, UserAnswerTest userAnswerTest)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var userAnswers = userAnswerTest.UserAnswerDTOs;
                    foreach (var item in userAnswers)
                    {
                        UserAnswer userAnswer = new UserAnswer();
                        userAnswer.AnswerId = item.AnswerId;
                        userAnswer.UserId = userId;
                        userAnswer.Selected = item.Selected;
                        userAnswer.SectionId = userAnswerTest.SectionId;
                        context.UserAnswers.Add(userAnswer);
                        context.SaveChanges();
                    }

                    var section = context.Sections.FirstOrDefault(o => o.SectionId == userAnswerTest.SectionId);
                    var paper = context.Papers.FirstOrDefault(o => o.PaperId == section.PaperId);
                    List<PaperQuestion> paperQuestions = context.PaperQuestions.Where(o => o.PaperId == paper.PaperId).ToList();
                    double diem = 0;
                    foreach (var item in paperQuestions)
                    {
                        var question = context.Questions.FirstOrDefault(o => o.QuestionId == item.QuestionId);
                        List < Answer > answers = context.Answers.Where(o => o.QuestionId == question.QuestionId).ToList();

                        /*foreach (var userAnswerInfor in userAnswers)
                        {

                        }*/
                        foreach (var answer in answers)
                        {
                            foreach (var userAnswer in userAnswers)
                            {
                                if(answer.IsCorrect == userAnswer.Selected)
                                {
                                    diem += 1;
                                }
                            }
                        }

                    }
                    Grade grade = new Grade();
                    grade.SectionId = userAnswerTest.SectionId;
                    grade.SubmitedDate = DateTime.Now;
                    grade.Score = diem;
                    grade.UserId = userId;
                    context.Grades.Add(grade);
                    context.SaveChanges();
                    userAnswerTest.UserId = userId;
                    return userAnswerTest;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
