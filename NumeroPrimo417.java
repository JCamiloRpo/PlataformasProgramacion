
public class NumeroPrimo417 {
	public static void main(String arg[]) {
		int i = 1, con = 1;
		while(con <= 417) {
			i++;
			int p = i-1;
			while(p >= 1) {
				if((i%p) == 0) break;
				p--;
			}
			if(p <= 1)con++;
		}
		System.out.print("Primo "+i+" en la posicion "+ con);
	}
	
	
}
