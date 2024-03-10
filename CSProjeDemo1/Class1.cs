using static CSProjeDemo1.Kitap;

namespace CSProjeDemo1
{
    public abstract class Kitap
    {
        public int ISBN { get; set; }
        public string Baslik {  get; set; }
        public string Yazar { get; set; }
        public DateOnly YayinYili { get; set; }
        public KitapDurum durum { get; set; }
        public enum KitapDurum
        {
            OduncAlinabilir,
            OduncVerildi,
            MevcutDegil

        }
    }

    public class KitapBilim : Kitap
    {
        
    }

    public class KitapRoman : Kitap
    {

    }
    public class KitapTarih : Kitap
    {

    }

    public interface IUye
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int UyeNo { get; set; }

        public void OduncAlma(Kitap kitap);
        public void OduncVerme(Kitap kitap);
    }

    public class Uye : IUye
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int UyeNo { get; set; }
        private List<Kitap> OduncKitaplar;

        public Uye(string ad, string soyad, int uyeNo)
        {
            this.Ad = ad;
            this.Soyad = soyad;
            this.UyeNo = uyeNo;
            this.OduncKitaplar = new List<Kitap>();
        }
        public void OduncAlma(Kitap kitap)
        {
            if (kitap.durum == KitapDurum.OduncAlinabilir)
            {
                kitap.durum = KitapDurum.OduncVerildi;
                OduncKitaplar.Add(kitap);
                Console.WriteLine($"{kitap.Baslik} kitabı ödünç alındı.");
            }
            else
            {
                Console.WriteLine($"{kitap.Baslik} kitabı şu anda ödünç alınamaz.");
            }
        }

        public void OduncVerme(Kitap kitap)
        {
            if (OduncKitaplar.Contains(kitap))
            {
                kitap.durum = KitapDurum.OduncAlinabilir;
                OduncKitaplar.Remove(kitap);
                Console.WriteLine($"{kitap.Baslik} kitabı iade edildi.");
            }
            else
            {
                Console.WriteLine($"{kitap.Baslik} kitabı zaten ödünçte değil.");
            }
        }
    }
}
