using System.Data;

namespace baocao.DTO
{
    public class ViTriLayMau
    {
        public string MaViTri { get; set; }
        public string MaHopDong { get; set; }
        public string TenViTri { get; set; }
        public string LoaiViTri { get; set; }

        public ViTriLayMau(string maViTri, string maHopDong, string tenViTri, string loaiViTri)
        {
            MaViTri = maViTri;
            MaHopDong = maHopDong;
            TenViTri = tenViTri;
            LoaiViTri = loaiViTri;
        }

        public ViTriLayMau(DataRow row)
        {
            MaViTri = row["ma_vi_tri"].ToString();
            MaHopDong = row["ma_hop_dong"].ToString();
            TenViTri = row["ten_vi_tri"].ToString();
            LoaiViTri = row["loai_vi_tri"].ToString();
        }
    }
}
