using MethodLibraryHvM2;
using System.Threading;

namespace TestProjectHvM
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestValidate()
        {
            int min = 4, max = 6;
            double value = 5.56;

            Assert.IsTrue(HeroisVsMonstreLibrary.Validate(min, max, value));
        }
        [TestMethod]
        public void TestCheckForCommas()
        {
            string names = "Arquera, Bàrbar, Maga, Druida";

            Assert.IsTrue(HeroisVsMonstreLibrary.CheckForCommas(names));
        }
        [TestMethod]
        public void TestCheckForCommas2()
        {
            string names = "Arquera, Bàrbar, Maga, Druida", expected = "Maga";
            int num = 3;

            Assert.AreEqual(HeroisVsMonstreLibrary.CheckForCommas(names,num),expected);
        }
        [TestMethod]
        public void TestEmptyOrder()
        {
            int[] expected = new int[] {0,0,0,0};
            int[] orderTurns = new int[] {23, 5546, 6, 76};

            Assert.AreEqual(HeroisVsMonstreLibrary.EmptyOrder(orderTurns), expected);
        }
        /*[TestMethod]
        public void TestOrderTurns()
        {
            no es por fer un test d'un resultat aleatori
        }*/
        [TestMethod]
        public void TestFightMenu()
        {
            int choice=1;
            double atkAtacker=10, hpMonstre=200, defMonstre=20, expected = 192;
            string nameAtacker="Arquera", monstre="el monstre";

            Assert.AreEqual(HeroisVsMonstreLibrary.FightMenu(choice, atkAtacker, nameAtacker, hpMonstre, defMonstre, monstre), expected);
        }

        [TestMethod]
        public void TestFightMenu2()
        {
            double atkAtacker = 10, hpMonstre = 200, defMonstre = 20, expected = 176;
            string nameAtacker = "Maga", monstre = "el monstre";

            Assert.AreEqual(HeroisVsMonstreLibrary.FightMenu(atkAtacker, nameAtacker, hpMonstre, defMonstre, monstre), expected);
        }

        [TestMethod]
        public void TestAttackMonster()
        {
            double atkMonster = 10, hpReciever = 200, defReciever = 20, expected = 196;
            string nameReciever = "Maga", monstre = "el monstre";
            bool def = true;

            Assert.AreEqual(HeroisVsMonstreLibrary.AttackMonster(atkMonster, hpReciever, defReciever, nameReciever, monstre, def), expected);
        }

        [TestMethod]
        public void TestHeal()
        {
            double hpHeal = 500, storedHeal = 700, expected = 600;
            string nameHeal = "Maga";
            int heal = 100;

            Assert.AreEqual(HeroisVsMonstreLibrary.Heal(hpHeal, storedHeal, nameHeal, heal), expected);
        }

        [TestMethod]
        public void TestSortArray()
        {
            double[] expected = new double[] {243545, 4353, 3453, 45, 9};
            double[] NumArray = new double[] { 3453, 4353, 45, 9, 243545 };

            Assert.AreEqual(HeroisVsMonstreLibrary.SortArray(NumArray), expected);
        }
    }
}