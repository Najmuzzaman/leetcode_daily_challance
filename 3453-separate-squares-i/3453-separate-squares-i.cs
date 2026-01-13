public class Solution {
    public double SeparateSquares(int[][] squares) {

      double totalArea=0;
      double minY=double.MaxValue;
      double maxY= double.MinValue;

      foreach(var sq in squares){
        long l= sq[2];
        totalArea+=l*l;
        minY=Math.Min(minY,sq[1]);
        maxY=Math.Max(maxY,sq[1]+l);
      }

      double target=totalArea/2.0;
      double low=minY;
      double high=maxY;

      for(int i=0;i<100;i++)
      {
        double mid= low + (high-low)/2;
        if(GetAreaBelow(squares,mid)<target)
          low=mid;
        
        else
          high=mid;
        
      }
      return low;   
    }

    private double GetAreaBelow(int[][] squares,double y ){

      double area=0;
      foreach(var sq in squares)
      {
        double bottom =sq[1];
        double side= sq[2];
        double top = bottom + side;

        if(y<=bottom)
          continue;
        
        else if(y>=top)
          area+=side*side;        
        else
          area+=(y-bottom) * side;
        
      }
      return area;
    }
}