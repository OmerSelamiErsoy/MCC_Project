using Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utility.Methods;

namespace WebApplication.Common
{
	public class OrderBasket
	{



		static string SessionName = "sessionBasket";

		public static BasketModelList myBasket
		{
			get { return (HttpContext.Current.Session[SessionName] == null) ? null : (BasketModelList)HttpContext.Current.Session[SessionName]; }
			set { HttpContext.Current.Session[SessionName] = value; }
		}

		public static bool Control(int productID)
		{
			bool result = false;
			if (myBasket != null)
				result = myBasket.BasketList.Exists(x => x.PRODUCT.ID == productID);

			return result;
		}

		public static void Clear()
		{
			HttpContext.Current.Session[SessionName] = null;
		}
		public static void Delete(int productID)
		{
			if (myBasket != null)
			{
				if (Control(productID))
				{
					BasketModelList BL = myBasket;
					BL.BasketList.RemoveAll(x => x.PRODUCT.ID == productID);
					myBasket = BL;
				}
			}
		}

		public static void AddOrUpdate(int productID, int AMOUNT, int ISEQUAL = 0)
		{
			if (AMOUNT > 0 && productID > 0)
			{
				if (myBasket != null)
				{
					BasketModelList BL = myBasket;

					if (Control(productID))
					{
						if (ISEQUAL.ToBoolean())  // Eşitler
							BL.BasketList.Where(x => x.PRODUCT.ID == productID).ToList()[0].AMOUNT = AMOUNT;
						else // Üstüne Ekler
							BL.BasketList.Where(x => x.PRODUCT.ID == productID).ToList()[0].AMOUNT += AMOUNT;

						myBasket = BL;
					}
					else
					{
						TBL_PRODUCTS P = TBL_PRODUCTS.SINGLE(productID, ISACTIVE: true);
						if (P != null) // ÜRÜN SİSTEMDE VARSA İŞLEM YAP
						{
							BasketModel BM = new BasketModel();
							BM.PRODUCT = P;
							BM.AMOUNT = AMOUNT;

							BL.BasketList.Add(BM);
							myBasket = BL;
						}
					}
				}
				else
				{
					TBL_PRODUCTS P = TBL_PRODUCTS.SINGLE(productID,ISACTIVE:true);
					if (P != null) // ÜRÜN SİSTEMDE VARSA İŞLEM YAP
					{

						BasketModel BM = new BasketModel();
						BM.PRODUCT = P;
						BM.AMOUNT = AMOUNT;

						BasketModelList BL = new BasketModelList();
						BL.BasketList = new List<BasketModel>() { BM };
						myBasket = BL;
					}

				}
			}
			
		}

	}

	[Serializable]
	public class BasketModelList
	{
		public List<BasketModel> BasketList { get; set; }

		public double TOTALAOMUNT { get { return BasketList.Sum(x => x.AMOUNT); } }
		public double TOTALPRICE { get { return BasketList.Sum(x => x.TOTALPRICE); } }
	}

	[Serializable]
	public class BasketModel
	{
		public TBL_PRODUCTS PRODUCT { get; set; }
		public int AMOUNT { get; set; }

		public double PRICETAXWITHOUT { get { return PRODUCT.PRICE / PRODUCT.TAX.ToTax(); } }
		public double TOTALPRICE { get { return PRODUCT.PRICE * AMOUNT; } }
	}
}