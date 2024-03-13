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

    public enum PosisiKarakterGameState { TENGKURAP, JONGKOK, BERDIRI, TERBANG };
    public enum Trigger { TOMBOL_W, TOMBOL_S, TOMBOL_X };

    public class PosisiKarakterGame
    {
        public PosisiKarakterGameState currentState = PosisiKarakterGameState.BERDIRI;

        public class Transition
        {

            public PosisiKarakterGameState stateAwal;
            public PosisiKarakterGameState stateAkhir;
            public Trigger trigger;
            public Transition(PosisiKarakterGameState stateAwal, PosisiKarakterGameState stateAkhir, Trigger trigger)
            {
                this.stateAwal = stateAwal;
                this.stateAkhir = stateAkhir;
                this.trigger = trigger;
            }
        }

        Transition[] transisi =
        {
            new Transition(PosisiKarakterGameState.TENGKURAP, PosisiKarakterGameState.JONGKOK, Trigger.TOMBOL_W),
            new Transition(PosisiKarakterGameState.JONGKOK, PosisiKarakterGameState.TENGKURAP, Trigger.TOMBOL_S),
            new Transition(PosisiKarakterGameState.JONGKOK, PosisiKarakterGameState.BERDIRI, Trigger.TOMBOL_W),
            new Transition(PosisiKarakterGameState.BERDIRI, PosisiKarakterGameState.JONGKOK, Trigger.TOMBOL_S),
            new Transition(PosisiKarakterGameState.BERDIRI, PosisiKarakterGameState.TERBANG, Trigger.TOMBOL_W),
            new Transition(PosisiKarakterGameState.TERBANG, PosisiKarakterGameState.BERDIRI, Trigger.TOMBOL_S),
            new Transition(PosisiKarakterGameState.TERBANG, PosisiKarakterGameState.JONGKOK, Trigger.TOMBOL_X),
        };

        public PosisiKarakterGameState GetNextState(PosisiKarakterGameState stateAwal, Trigger trigger)
        {
            PosisiKarakterGameState stateAkhir = stateAwal;

            for (int i = 0; i < transisi.Length; i++)
            {
                Transition perubahan = transisi[i];

                if (stateAwal == perubahan.stateAwal && trigger == perubahan.trigger)
                {
                    stateAkhir = perubahan.stateAkhir;
                }
            }

            return stateAkhir;
        }

        public void ActivateTrigger(Trigger trigger)
        {
            PosisiKarakterGameState stateAwal = currentState;
            currentState = GetNextState(currentState, trigger);

            // Event when state changes
            if(stateAwal == PosisiKarakterGameState.TERBANG && currentState == PosisiKarakterGameState.JONGKOK)
            {
                Console.WriteLine("Posisi Landing");
            }

            if(stateAwal == PosisiKarakterGameState.BERDIRI && currentState == PosisiKarakterGameState.TERBANG)
            {
                Console.WriteLine("Posisi Take Off");
            }
        }
    }

    private static void Main(string[] args)
    {
        PosisiKarakterGame game = new PosisiKarakterGame();
        Console.WriteLine("State Awal Sedang Berdiri");
        game.ActivateTrigger(Trigger.TOMBOL_W);
        game.ActivateTrigger(Trigger.TOMBOL_X);
    }
}