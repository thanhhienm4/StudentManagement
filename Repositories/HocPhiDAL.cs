using Dapper;
using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories
{
    class HocPhiDAL
    {
        public DataResponse<SINHVIEN> GetInfoSinhvien(string maSV)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<SINHVIEN>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.SP_THONGTINSINHVIEN @masv";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@masv", maSV);
                var data = Program.conn.Query<SINHVIEN>(command, parameters).FirstOrDefault();
                return new DataResponeSuccess<SINHVIEN>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<SINHVIEN>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }

        public DataResponse<KHOALOP> GetTenKhoaByMaLop(string maLop)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<KHOALOP>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.SP_GetTenKhoaByMaLop @maLop";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@maLop", maLop);
                var data = Program.conn.Query<KHOALOP>(command, parameters).FirstOrDefault();
                return new DataResponeSuccess<KHOALOP>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<KHOALOP>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }

        public DataResponse<List<HOCPHITONGHOP>> DSHocPhiByMASV(string maSV)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<HOCPHITONGHOP>>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.SP_DSHocPhiByMasv @masv";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@masv", maSV);
                var data = Program.conn.Query<HOCPHITONGHOP>(command, parameters).ToList();
                return new DataResponeSuccess<List<HOCPHITONGHOP>>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<List<HOCPHITONGHOP>>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }

        public DataResponse<List<CT_DONGHOCPHI>> DSCTHocPhi(string maSV, string nienKhoa, int hocKy)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<CT_DONGHOCPHI>>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.SP_CTDongHocPhi @masv, @nienkhoa, @hocky";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@masv", maSV);
                parameters.Add("@nienkhoa", nienKhoa);
                parameters.Add("@hocky", hocKy);
                var data = Program.conn.Query<CT_DONGHOCPHI>(command, parameters).ToList();
                return new DataResponeSuccess<List<CT_DONGHOCPHI>>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<List<CT_DONGHOCPHI>>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }

        public DataResponse<bool> ThemHocPhi(string maSV, string nienKhoa, int hocKy, int hocPhi)
        {
            if (!BaseDAl.Connect())
            {
                return new DataResponeFail<bool>("Lỗi kết nối");
            }
            try
            {
                string command = "exec dbo.SP_ThemHocPhi @masv, @nienkhoa, @hocky, @hocphi";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@masv", maSV);
                parameters.Add("@nienkhoa", nienKhoa);
                parameters.Add("@hocky", hocKy);
                parameters.Add("@hocphi", hocPhi);
                Program.conn.Execute(command, parameters);
                return new DataResponeSuccess<bool>(true);
            }
            catch(Exception e)
            {
                return new DataResponeFail<bool>("Lỗi hệ thống, " + e.ToString());
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }

        public DataResponse<bool> SVDongHocPhi(string maSV, string nienKhoa, int hocKy, DateTime ngayDong, int hocPhi)
        {
            if (!BaseDAl.Connect())
            {
                return new DataResponeFail<bool>("Lỗi kết nối");
            }
            try
            {
                string command = "exec dbo.SP_SVDongHocPhi @masv, @nienkhoa, @hocky, @ngaydong, @sotiendong";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@masv", maSV);
                parameters.Add("@nienkhoa", nienKhoa);
                parameters.Add("@hocky", hocKy);
                parameters.Add("@ngaydong", ngayDong);
                parameters.Add("@sotiendong", hocPhi);
                Program.conn.Execute(command, parameters);
                return new DataResponeSuccess<bool>(true);
            }
            catch (Exception e)
            {
                return new DataResponeFail<bool>("Lỗi hệ thống, " + e.ToString());
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }

        public DataResponse<bool> CheckExistedSV(string maSV)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<bool>("Lỗi kết nối");
            try
            {
                string command = "select [dbo].[checkExistedSV] (@MASV)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MASV", maSV);
                var res = Program.conn.ExecuteScalar<bool>(command, parameters);
                return new DataResponeSuccess<bool>(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<bool>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }

        public DataResponse<bool> CheckExistedLop(string maLop)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<bool>("Lỗi kết nối");
            try
            {
                string command = "select [dbo].[checkExistedLop] (@MALOP)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MALOP", maLop);
                var res = Program.conn.ExecuteScalar<bool>(command, parameters);
                return new DataResponeSuccess<bool>(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<bool>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }

        public DataResponse<List<INHOCPHI>> INDSHPByLop(string maLop, string nienKhoa, int hocKy)
        {
            if (!BaseDAl.Connect())
                return new DataResponeFail<List<INHOCPHI>>("Lỗi kết nối");
            try
            {
                string command = "exec dbo.SP_InDSHPByLop @malop, @nienkhoa, @hocky";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@malop", maLop);
                parameters.Add("@nienkhoa", nienKhoa);
                parameters.Add("@hocky", hocKy);
                var data = Program.conn.Query<INHOCPHI>(command, parameters).ToList();
                return new DataResponeSuccess<List<INHOCPHI>>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new DataResponeFail<List<INHOCPHI>>("Lỗi hệ thống");
            }
            finally
            {
                BaseDAl.DisConnect();
            }
        }
    }
}
