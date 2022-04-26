using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Tests
{
    [TestClass()]
    public class SchiffeVersenkenTests
    {
        /// <summary>
        ///A test for SetShipToPosition
        ///</summary>
        [TestMethod()]
        public void T01_SetShipToPositionTestSimple()
        {
            Board.Init(3, 3, "UnitTest 1");
            bool ok = Program.SetShipToPosition(0, 0);
            Assert.IsTrue(ok, "Erstes Positionieren ging schief");
            Assert.AreEqual("x", Board.GetText(0, 0), "Zurücklesen funktioniert nicht");
            ok = Program.SetShipToPosition(1, 1);
            Assert.IsTrue(ok, "Zweites Positionieren ging schief");
            Assert.AreEqual("x", Board.GetText(1, 1), "Zweites Zurücklesen funktioniert nicht");
            ok = Program.SetShipToPosition(2, 2);
            Assert.IsTrue(ok, "Drittes Positionieren ging schief");
        }

        /// <summary>
        ///A test for SetShipToPosition
        ///</summary>
        [TestMethod()]
        public void T02_SetShipToPositionTestFailure()
        {
            Board.Init(3, 3, "UnitTest Failure");
            bool ok = Program.SetShipToPosition(0, 0);
            Assert.IsTrue(ok, "Erstes Positionieren ging schief");
            ok = Program.SetShipToPosition(-1, 0);
            Assert.IsFalse(ok, "Negative Koordinate");
            ok = Program.SetShipToPosition(4, 0);
            Assert.IsFalse(ok, "Zu große Koordinate");
            ok = Program.SetShipToPosition(0, 0);
            ok = Program.SetShipToPosition(0, 0);
            Assert.IsFalse(ok, "Mehrmals auf gleiche Position");
        }

        /// <summary>
        ///A test for GetMinDistanceToNextShip
        ///</summary>
        [TestMethod()]
        public void T03_GetMinDistanceToNextShipTest()
        {
            Board.Init(5, 5, "UnitTest GetDistance");
            double distance = Program.GetMinDistanceToNextShip(2, 2);
            Assert.AreEqual(double.MaxValue, distance, 0.01, "Es gibt kein Schiff am Board");
            bool ok = Program.SetShipToPosition(3, 4);
            distance = Program.GetMinDistanceToNextShip(0, 0);
            Assert.AreEqual(5.0, distance, 0.01, "Ein Schiff");
            ok = Program.SetShipToPosition(0, 0);
            distance = Program.GetMinDistanceToNextShip(2, 2);
            Assert.AreEqual(Math.Sqrt(5), distance, 0.01, "Zwei Schiffe");
            ok = Program.SetShipToPosition(3, 1);
            distance = Program.GetMinDistanceToNextShip(2, 2);
            Assert.AreEqual(Math.Sqrt(2), distance, 0.01, "Drei Schiffe");
            ok = Program.SetShipToPosition(2, 1);
            distance = Program.GetMinDistanceToNextShip(2, 2);
            Assert.AreEqual(1, distance, 0.01, "Vier Schiffe");
            ok = Program.SetShipToPosition(2, 2);
            distance = Program.GetMinDistanceToNextShip(2, 2);
            Assert.AreEqual(0, distance, 0.01, "Fünf Schiffe");
        }

    }
}