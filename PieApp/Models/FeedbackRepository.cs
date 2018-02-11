using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieApp.Models
{
    public class FeedbackRepository : IFeedbackRepository
    {
        //injeção de dependencia no ctor
        private readonly AppDbContext _appDbContext;
        public FeedbackRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //deploy da interface ifeedbackRepository
        public void AddFeedback(Feedback feedback)
        {
            _appDbContext.Feedbacks.Add(feedback);
            _appDbContext.SaveChanges();
        }
    }
}
