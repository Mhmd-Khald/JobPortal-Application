using System;

namespace Project.Apis.Dto
{
    public class ToReturnJoThatUserApply
    {
        public string UserId { get; set; }
        public string ApplicantId { get; set; }
        public string Name { get; set; }
        public string piCtrueUrl { get; set; }
        public string Title { get; set; }
        public DateTime DateApplied { get; set; }
        public string message { get; set; }
        public int Jobid { get; set; }
        
    }
}
