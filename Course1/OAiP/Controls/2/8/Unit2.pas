unit Unit2;

interface
uses Grids,Dialogs,sysutils;
type
   Tkey=integer;
   Tinf=record
      f:string[20];
      k:Tkey;
   end;
   mas=array [1..1] of Tinf;
   Pmas=^mas;

   Tzad=class(Tobject)
      a,a1:pmas;
      n,mt:Integer;
      constructor create;
      procedure addk(inf:Tinf);
      procedure read1(var inf:Tinf);
      procedure print(var sgrid:Tstringgrid);
   end;

implementation


constructor Tzad.create;
begin
   inherited create;
   n:=0;
   mt:=sizeof(Tinf);
   a:=nil;
end;



procedure Tzad.addk;
var i:word;
begin
   getmem(a1,(n+1)*mt);
   a1^[n+1]:=inf;
   if n>0 then
   begin
      for i:=1 to n do
         a1^[i]:=a^[i];
      freemem(a,n*mt);
   end;
   a:=a1;
   inc(n);
end;



procedure Tzad.read1;
var i:word;
begin
   if n>0 then
   begin
      inf:=a[1];
      dec(n);
      if n>0 then
      begin
         getmem(a1,n*mt);
         for i:=1 to n do
            a1[i]:=a[i+1];
      end
      else a1:=nil;
      freemem(a,(n+1)*mt);
      a:=a1;
   end
   else showmessage('Список пуст!');
end;


procedure Tzad.print;
var i:word;
begin
   for i:=1 to n do
   begin
      sgrid.Cells[i,0]:=a[i].f;
      sgrid.Cells[i,1]:=inttostr(a[i].k);
   end;


end;


end.
 