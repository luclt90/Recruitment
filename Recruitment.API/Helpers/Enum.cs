namespace Recruitment.API.Helpers
{
    public static class Enum
    {
        public enum EnumTypeJob
        {
            Hot = 1,
            Normal = 2,
            Stop = 3,
            Delete = 4
        }

        public enum EnumStatusJob
        {
            Approvaling = 1,
            Active = 2,
            Inactive = 3,
            Deleted = 4
        }

        public enum EnumCareer
        {
            BanHangTiepThi = 1,
            HangTieuDung = 2,
            KyThuat = 3,
            DichVu = 4,
            MayTinhIT = 5,
            SucKhoe = 6,
            SanXuat = 7,
            HanhChinhNhanSu = 8,
            KeToanTaiChinh = 9,
            TruyenThongMedia = 10,
            XayDung = 11,
            GiaoDucDaoTao = 12,
            KhoaHoc = 13,
            KhachSanDuLich = 14,
            NganhKhac = 15
        }

        public enum StatusRecruit
        {
            Active = 1,
            Block = 2,
            Approvaling = 3,
            Deleted = 4
        }

        public enum StatusCandidate
        {
            Active = 1,
            Block = 2,
            Approvaling = 3,
            Deleted = 4
        }

        public enum TypeUpdate
        {
            UpdateInformation = 1,
            UpdateContact = 2
        }
        
    }
}