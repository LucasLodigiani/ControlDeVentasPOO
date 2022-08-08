using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeVentas
{
    class Ventas
    {
        private string _Producto;
        private int _cantidad;

        
        public string Producto
        {
            get { return _Producto; }
            set { _Producto = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        //Asignacion de precio de los productos
        public double AsignarPrecio()
        {
            switch (Producto)
            {
                case "Teclado": return 35;
                case "Impresora": return 350;
                case "Monitor": return 550;
                case "Parlante": return 50;
                case "Mouse": return 20;
            }
            return 0; //Y si no hay ninguno retorna 0
        }

        //Calcular SubTotal
        public double CalcularSubTotal()
        {
            return AsignarPrecio() * Cantidad;
        }

        //Calcular Descuento
        public double CalcularDescuento()
        {
            double subTotal = CalcularSubTotal();

            if (subTotal <= 300) return 5.0 / 100 * subTotal;
            else if (subTotal > 300 && subTotal <= 500) return 10.0 / 100 * subTotal;
            else return 12.5 / 100 * subTotal;
        }

        //Calcular Neto
        public double CalcularNeto()
        {
            return CalcularSubTotal() - CalcularDescuento();
        }

    }
}
