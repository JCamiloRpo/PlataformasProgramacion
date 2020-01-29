
public class NumeroPrimo417 {
	static class Primo{
		public static int Posicion(int pos) {
			int primo=1,con=1;
			while(con <= pos) {
				primo++;
				if(isPrimo(primo))con++;
			}
			return primo;
		}
		public static boolean isPrimo(int primo) {
			int divisor = primo - 1;
			while(divisor > 1) {
				if((primo%divisor) == 0) return false;//Si se logra residuo cero quiere decir que no es primo
				divisor--;
			}//Sale del ciclo con el divisor = 1, por tanto si es primo
			return true;
		}
	}
	
	public static void main(String arg[]) {
		int pos = 417;
		System.out.print("Primo "+Primo.Posicion(pos)+" en la posicion "+ pos);
	}
}
