using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolOperationsApi.Models
{
    public class StudentRegisterBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime EnrolmentDate { get; set; }

        public string St_Address1 { get; set; }

        public string St_Address2 { get; set; }

        public string St_PostCode { get; set; }

        public string St_Telephone { get; set; }

        public string _ImageFileUrl { get; set; }

        [Required]
        public int StandardId { get; set; }
    }

    public class TeacherRegisterBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }



        public DateTime JoinDate { get; set; }

        public string Tr_Address1 { get; set; }

        public string Tr_Address2 { get; set; }

        public string Tr_PostCode { get; set; }

        public string Tr_Telephone { get; set; }

        public string _ImageFileUrl { get; set; }

    }

    public class ParentRegisterBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string RelationType { get; set; }//Mother or Father etc

        public DateTime JoinDate { get; set; }

        public string ParentAddress1 { get; set; }

        public string ParentAddress2 { get; set; }

        public string ParentPostCode { get; set; }

        public string ParentTelephone { get; set; }

        public string _ImageFileUrl { get; set; }

    }

    public class OperationalStaffRegisterBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string OpStaffRole { get; set; }

        public DateTime StartDate { get; set; }

        public string OpStaffAddress1 { get; set; }

        public string OpStaffAddress2 { get; set; }

        public string OpStaffPostCode { get; set; }

        public string OpStaffTelephone { get; set; }

        public string _ImageFileUrl { get; set; }

        public int SchoolId { get; set; }
    }

    public class RegisterBindingModels
    {
    }
}