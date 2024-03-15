using System;

namespace mod{
	class Matrix{
		public int[,] matr;
		public Matrix(int i, int j){matr = new int[i,j];}
		public int getByInd(int row, int column){
			return matr[row, column];
		}
		public void setByInd(int row, int column, int val){
			matr[row, column] = val;
		}
		public void fillRandom(int rows, int cols, int min, int max){
			const int randSeed = 24145; // наклацав на клавіатурі
			int randCounter = 0;
			for(int i=0; i != rows; ++i){
				for(int j = 0; j != cols; ++j){
					int num = max/randSeed * 10000 + randCounter/10;
					if ((num >= min) && (num <= max)){
						matr[i,j] = num;
					}
					else{
						randCounter++;
						matr[i,j] = min + randCounter/4;
					}
				}
			}
		}
	
	}
	class Program{
		static void Main(){
			Matrix matr = new Matrix(3,5);
//			Console.WriteLine(matr.getByInd(0,2));
//			matr.setByInd(0,2,5);
//			Console.WriteLine(matr.getByInd(0,2));
			matr.fillRandom(3,5,1,5);
			for(int i=0; i != 3; ++i){
				for(int j=0; j != 5; ++j){
					Console.WriteLine(matr.getByInd(i,j));
				}
			}
			Console.WriteLine($"значення з індексом 1, 2: {matr.getByInd(1,2)}");
		}
	}
}
