//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoggyStyleWS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PetAdoption
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PetAdoption()
        {
            this.AdoptionRequest = new HashSet<AdoptionRequest>();
        }
    
        public int PetAdoptionId { get; set; }
        public int PetId { get; set; }
        public string Description { get; set; }
        public Nullable<int> PetShelter { get; set; }
        public string State { get; set; }
        public Nullable<int> UserId { get; set; }
        public System.DateTime CreatioDate { get; set; }
        public System.DateTime EndDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdoptionRequest> AdoptionRequest { get; set; }
    }
}