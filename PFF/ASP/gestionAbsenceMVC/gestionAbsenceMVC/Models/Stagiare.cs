//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gestionAbsenceMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stagiare
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stagiare()
        {
            this.Absences = new HashSet<Absence>();
        }
    
        public int id_S { get; set; }
        public string nom_S { get; set; }
        public string prenom_S { get; set; }
        public string sexe_S { get; set; }
        public Nullable<int> id_G { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Absence> Absences { get; set; }
        public virtual Groupe Groupe { get; set; }
    }
}
