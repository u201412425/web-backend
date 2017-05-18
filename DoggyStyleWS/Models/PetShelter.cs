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
    
    public partial class PetShelter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PetShelter()
        {
            this.Pet = new HashSet<Pet>();
            this.PetShelterImage = new HashSet<PetShelterImage>();
            this.PetShelterLocal = new HashSet<PetShelterLocal>();
        }
    
        public int PetShelterId { get; set; }
        public int UserId { get; set; }
        public int Name { get; set; }
        public int Phone { get; set; }
        public string Descriptiom { get; set; }
        public int Capacity { get; set; }
        public int AviableCapacity { get; set; }
        public string State { get; set; }
        public string ImagenUrl { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pet> Pet { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PetShelterImage> PetShelterImage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PetShelterLocal> PetShelterLocal { get; set; }
    }
}
