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
      procedure sortsliv;
   end;

implementation

procedure Tzad.sortsliv;
   procedure slip(L,m,R:word);
   var i,j,k:word; c:mas;
   begin
      i:=l; k:=1; j:=m+1;
      while (i<=m)and(j<=r) do
         if a[i].k<a[j].k then
         begin
            c[k]:=a[i];
            inc(i);
            inc(k);
         end
         else begin
            c[k]:=a[j];
            inc(j);
            inc(k);
         end;

      while i<=m do
      begin
         c[k]:=a[i];
         inc(i);
         inc(k);
      end;

      while j<=R do
      begin
         c[k]:=a[j];
         inc(j);
         inc(k);
      end;
      k:=0;
      for i:=L to R do
      begin
         inc(k);
         a[i]:=c[k];
      end;
   end;


   procedure srsl(L,R:word);
   var m:word;
   begin
      if l<>r then
      begin
         m:=(l+r) div 2;
         srsl(l,m);
         srsl(m+1,r);
         slip(l,m,r);
      end;
   end;


begin
   srsl(1,n);
end;

end.
 