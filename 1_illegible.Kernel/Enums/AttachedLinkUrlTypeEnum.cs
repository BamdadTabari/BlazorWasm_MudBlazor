

using System.ComponentModel.DataAnnotations;

namespace illegible.Kernel.Enums
{
    // this enum defined for special links 
    // to set more detail about external links
    // and Observe owasp protocls
    // to "Be Safe" Against "CSRF" And "Social Engineering" Attacks
    public enum AttachedLinkType
    {

        [Display(Name = "OtherSites")]
        OtherSites = 0,

        [Display(Name = "GitHub")]
        GitHub = 1 ,

        [Display(Name = "GitLab")]
        GitLab = 2 ,

        [Display(Name = "YouTube")]
        YouTube = 3 ,

        [Display(Name = "StackOverFlow")]
        StackOverFlow = 4,
    }
}
