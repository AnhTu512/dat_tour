using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class TourDao
    {
        DuLich_DataBase db = null;
        public TourDao()
        {
            db = new DuLich_DataBase();
        }
        public long Them(Tour entity)
        {
            db.Tours.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool CapNhat(Tour entity)
        {
            var tour = db.Tours.Find(entity.ID);
            tour.TenTour = entity.TenTour;
            tour.MoTa = entity.MoTa;
            tour.LichTrinh = entity.LichTrinh;
            tour.BangGia = entity.BangGia;
            tour.ThongTinLienQuan = entity.ThongTinLienQuan;
            tour.TinhTrang = entity.TinhTrang;
            tour.Images = entity.Images;
            tour.DiaDiemKhoiHanh = entity.DiaDiemKhoiHanh;
            tour.ThoiLuong = entity.ThoiLuong;
            tour.DiemDen = entity.DiemDen;
            tour.PhuongTien = entity.PhuongTien;
            tour.NgayCapNhat = DateTime.Now;
            db.SaveChanges();
            return true;

        }
        public bool Xoa(int id)
        {
            try
            {
                var tour = db.Tours.Find(id);
                db.Tours.Remove(tour);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Tour> ListTour(int tinhtrang)
        {
            return db.Tours.OrderByDescending(x => x.ID).Take(tinhtrang).ToList();
        }
        public List<Tour> DetailTour()
        {
            return db.Tours.OrderByDescending(x => x.ID).ToList();
        }

        public Tour ViewDetail(long id)
        {
            return db.Tours.Find(id);
        }
        public Tour GetById(string tentour)
        {
            return db.Tours.SingleOrDefault(x => x.TenTour == tentour);
        }
        public IEnumerable<Tour> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Tour> model = db.Tours;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenTour.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}
