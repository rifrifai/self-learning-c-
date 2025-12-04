// See https://aka.ms/new-console-template for more information
namespace ProjectLatihan;
class WorkoutSession
{
    public DateTime Tanggal { get; set; }
    public string JenisOlahraga { get; set; } = string.Empty;
    public int DurasiMenit { get; set; }
}

class Program
{
    static List<WorkoutSession> riwayatOlahraga = [];

    static void Main()
    {
        Console.WriteLine("=== Aplikasi Pencatat Olahraga ===");

        while (true)
        {
            Console.WriteLine("\nPilihan Menu: ");
            Console.WriteLine("1. Catat Olahraga baru");
            Console.WriteLine("2. Lihat Riwayat");
            Console.WriteLine("3. Keluar");
            Console.Write("Pilihan Kamu (1-3): ");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    TambahData();
                    break;
                case "2":
                    TampilkanData();
                    break;
                case "3":
                    Console.WriteLine("Tetap semangat! Bye!");
                    return;
                default:
                    Console.WriteLine("Pilihan tidak valid, coba lagi.");
                    break;
            }
        }
    }

    static void TambahData()
    {
        Console.WriteLine("\n-- Tambah Data Baru --");
        
        Console.Write("Jenis Olahraga (misal: lari, gym): ");
        string? nama = Console.ReadLine();

        Console.Write("Durasi (menit): ");
        string? durasiInput = Console.ReadLine();

        int durasi = int.Parse(durasiInput!);

        // masukkan data ke dalam list
        WorkoutSession sesiBaru = new();
        sesiBaru.Tanggal = DateTime.Now;
        sesiBaru.JenisOlahraga = nama!;
        sesiBaru.DurasiMenit = durasi;

        riwayatOlahraga.Add(sesiBaru);

        Console.WriteLine("Data berhasil disimpan!");
    }

    static void TampilkanData()
    {
        Console.WriteLine("-- Riwayat Olahraga --");

        if(riwayatOlahraga.Count == 0)
        {
            Console.WriteLine("Belum ada data olahraga. Yuk mulai gerak!");
        } else
        {
            foreach (var item in riwayatOlahraga)
            {
                int kalori = item.DurasiMenit * 7;

                Console.WriteLine($"-{item.Tanggal.ToShortDateString()}: {item.JenisOlahraga} selama {item.DurasiMenit} menit ({kalori} kalori) ");
            }
        }
    }
}