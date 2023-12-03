using System.ComponentModel.DataAnnotations;

namespace Medicoz.MVC.ViewModels
{
    public class DoctorDetailReservationViewModel
    {
        [DataType(DataType.DateTime)]
        public DateTime ReservationDate { get; set; }
        public string PasentId { get; set; }
        public string PasentName { get; set; }
        public string PasentPhone { get; set; }
        public string PasentEmail { get; set; }
        public string PasentNotes { get; set; }
    }
}
