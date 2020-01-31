using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetGrooming.Models.ViewModels
{
    public class UpdatePet
    {
        //What information does it need 
        //Needs a list of species and individual pet
        // This class does not have any impact on the databse 
        //Solely for containing information that you need

        public Pet pet { get; set; }
        public List<Species> species { get; set; }
    }
}