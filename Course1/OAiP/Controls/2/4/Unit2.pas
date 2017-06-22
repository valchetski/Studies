unit Unit2;

interface
type
   Tkey=word;
   Tinf=record
      f:String;
      k:Tkey;
   end;

   mas=array [1..50] of Tinf;

   Tzad=class(Tobject)
      n:word;
      a:mas;
      procedure quicksort;
   end;



implementation



procedure Tzad.quicksort;
   procedure sort(L,R:word);
   var i,j:word; w:Tinf; X:tkey;
   begin
      i:=L;
      j:=R;
      x:=a[(L+R) div 2].k;
      repeat
         while a[i].k<x do inc(i);
         while a[j].k>x do dec(j);
         if i<=j then
         begin
            w:=a[i];
            a[i]:=a[j];
            a[j]:=w;
            inc(i);
            dec(j);
         end;
      until j<i;
      if L<=j then sort(L,j);
      if i<=R then sort(i,R);
   end;
begin
   sort(1,n);
end;

end.
 