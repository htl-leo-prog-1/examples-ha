/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: CoffeeSlotMachine
*--------------------------------------------------------------
*/

namespace CoffeeSlotMachine
{
    using System;

    public class CoffeeSlotMachine
    {
        public int CoinsInDepot
        {
            get { return CommonTools.Sum(_coinsAmount); }
        }

        public int Credit { get; private set; }

        public int ProductsAvailable { get; private set; }

        const int PriceOfProducts = 50;

        string[] _products;

        int[] _acceptedCoinValues = { 5, 10, 20, 50, 100, 200 };
        int[] _coinsAmount;

        int[] _boughtProducts;

        int[] _insertedCoins;

        public CoffeeSlotMachine() : this(new[] { 3, 3, 3, 3, 3, 3 }, new[] { "Cappuccino", "Mocca", "Kakao" })
        {
        }

        public CoffeeSlotMachine(int[] initialCoinsAmount, string[] products)
        {
            _coinsAmount = initialCoinsAmount.Clone() as int[];

            _products         = products.Clone() as string[];
            ProductsAvailable = _products.Length;
            _boughtProducts   = new int[_products.Length];

            CancelOrder();
        }

        public bool InsertCoin(int coin)
        {
            var index = CommonTools.IndexOf(_acceptedCoinValues, coin);

            if (index < 0 || Credit >= PriceOfProducts)
            {
                return false;
            }

            _insertedCoins[index]++;
            Credit += coin;
            return true;
        }

        public bool SelectProduct(string product, out int[] returnCoins, out int donation)
        {
            returnCoins = new int[_acceptedCoinValues.Length];

            int productIdx = CommonTools.IndexOf(_products, product);

            if (productIdx < 0 || Credit < PriceOfProducts)
            {
                donation = 0;
                return false;
            }

            _boughtProducts[productIdx]++;

            for (int i = 0; i < _insertedCoins.Length; i++)
            {
                _coinsAmount[i] += _insertedCoins[i];
            }

            donation = Credit - PriceOfProducts;

            for (int coinIndex = _acceptedCoinValues.Length - 1; coinIndex >= 0; coinIndex--)
            {
                var needCoinsOfAmount = donation / _acceptedCoinValues[coinIndex];
                var countOfAmount     = Math.Min(needCoinsOfAmount, _coinsAmount[coinIndex]);

                if (countOfAmount > 0)
                {
                    returnCoins[coinIndex]  =  countOfAmount;
                    _coinsAmount[coinIndex] -= countOfAmount;
                    donation                -= _acceptedCoinValues[coinIndex] * countOfAmount;
                }
            }

            CancelOrder();

            return true;
        }

        public int[] CancelOrder()
        {
            var order = _insertedCoins;

            _insertedCoins = new int[_acceptedCoinValues.Length];
            Credit         = 0;

            return order;
        }

        public int EmptyDepot()
        {
            int cents = 0;

            for (int i = 0; i < _coinsAmount.Length; i++)
            {
                cents           += _coinsAmount[i] * _acceptedCoinValues[i];
                _coinsAmount[i] =  0;
            }

            return cents;
        }

        public bool GetCounterForProduct(string product, out int counter)
        {
            int productIdx = CommonTools.IndexOf(_products, product);

            if (productIdx < 0)
            {
                counter = 0;
                return false;
            }

            counter = _boughtProducts[productIdx];
            return true;
        }

        public bool GetCounterForCoin(int coin, out int counter)
        {
            int index = CommonTools.IndexOf(_acceptedCoinValues, coin);

            if (index < 0)
            {
                counter = 0;
                return false;
            }

            counter = _coinsAmount[index];
            return true;
        }
    }
}