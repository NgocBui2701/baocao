namespace baocao.DTO
{
    public class KetQua
    {
        public string MaHopDong { get; set; }
        public string MaDonHang { get; set; }
        public string MaViTri { get; set; }
        public string MaThongSo { get; set; }
        public string KetQuaGiaTri { get; set; }
        public bool AnLanQuanTrac { get; set; }
        public string KetLuan { get; set; }
        public string Loai { get; set; } 
        public string NguoiPhanTich { get; set; }

        public KetQua() { }
        
        public KetQua(string maHopDong, string maDonHang, string maViTri, string maThongSo, string ketQua = null,
                      bool anLanQuanTrac = false, string ketLuan = null, string loai = null, string nguoiPhanTich = null)
        {
            MaHopDong = maHopDong;
            MaDonHang = maDonHang;
            MaViTri = maViTri;
            MaThongSo = maThongSo;
            KetQuaGiaTri = ketQua;
            AnLanQuanTrac = anLanQuanTrac;
            KetLuan = ketLuan;
            Loai = loai;
            NguoiPhanTich = nguoiPhanTich;
        }
    }

}
