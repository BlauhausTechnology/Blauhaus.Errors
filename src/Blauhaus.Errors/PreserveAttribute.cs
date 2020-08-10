using Blauhaus.Errors;

[assembly:Preserve]

namespace Blauhaus.Errors
{
   
    [System.AttributeUsage(System.AttributeTargets.All)]
    public class PreserveAttribute : System.Attribute 
    {
        public PreserveAttribute () {}
        public bool Conditional { get; set; }


    }
}