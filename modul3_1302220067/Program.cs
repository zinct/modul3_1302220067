internal class Program
{
    public enum NamaBuah
    {
        Apel,
        Aprikot,
        Alpukat,
        Pisang,
        Paprika,
        Blackberry,
        Ceri,
        Kelapa,
        Jagung
    }

    public class KodeBuah
    {
        public static String getKodeBuah(NamaBuah namaBuah)
        {
            String[] kodeBuah = { "A00", "B00", "C00", "D00", "E00", "F00", "H00", "I00", "J00" };
            return kodeBuah[(int) namaBuah];
        }
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Buah Alpukat merupakan kode : " + KodeBuah.getKodeBuah(NamaBuah.Alpukat));
        Console.WriteLine("Buah Paprika merupakan kode : " + KodeBuah.getKodeBuah(NamaBuah.Paprika));
    }
}