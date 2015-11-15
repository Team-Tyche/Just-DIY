namespace Just_DIY.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;
    using Just_DIY.Data.Data;
    using Just_DIY.Models;
    using Just_DIY.Models.Votes;

    public class VotesController : ApiController
    {
        private IJustDIYData data;

        public VotesController(IJustDIYData data)
        {
            this.data = data;
        }

        public IHttpActionResult Post([FromBody]VoteBindingModel vote)
        {
            if (this.data.Votes.All().Any(x => x.ProjectId == vote.ProjectId && x.UserId == vote.UserId))
            {
                return this.BadRequest("You already voted for this project.");
            }

            var newVote = Mapper.Map<Vote>(vote);
            this.data.Votes.Add(newVote);
            var project = this.data.Projects.Find(vote.ProjectId);
            project.Points += vote.Value;
            this.data.Projects.Update(project);

            this.data.SaveChanges();

            return this.Ok();
        }
    }
}