using System.Text;

namespace QLHieuThuoc.Model.DungNhanh
{
    class TaoMaNgauNhien
    {
        public string TaoMa()
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            StringBuilder result = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 6; i++)
            {
                int index = random.Next(chars.Length);
                result.Append(chars[index]);
            }

            return $"#{result.ToString()}";
        }
    }
}
