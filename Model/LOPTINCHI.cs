namespace StudentManagement.Model
{

    public partial class LOPTINCHI
    {

        public int MALTC { get; set; }
        public string NIENKHOA { get; set; }
        public int HOCKY { get; set; }
        public string MAMH { get; set; }
        public string TENMH { get; set; }
        public int NHOM { get; set; }
        public string MAGV { get; set; }
        public string TENGV { get; set; }
        public string KHOA { get; set; }
        public string MAKHOA { get; set; }
        public int SOSVTOITHIEU { get; set; }
        public bool HUYLOP { get; set; }


        // extend
        public int SOSVDANGKY { get; set; }
        public bool CHON { get; set; }
        public string TRANGTHAI { get; set; }
        public LOPTINCHI()
        {
            this.TRANGTHAI = "Đã lưu";
        }


    }
}
