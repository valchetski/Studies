unit Unit2;

interface
type
   Tkey=integer;
   tinf=record
      f:string[50];
      k:Tkey;
   end;

   Psel=^sel;
   sel=record
      inf:Tinf;
      a:psel;
   end;


   Tzad=class(Tobject)
      sp,sp1,spk:Psel;
      constructor create;
      procedure addk(inf:Tinf);
      procedure read1(var Inf:Tinf);
      procedure sortslip;
   end;


implementation


constructor Tzad.create;
begin
   inherited create;
   sp1:=nil;
   spk:=nil;
end;



procedure Tzad.addk;
begin
   new(sp);
   sp.inf:=inf;
   sp.a:=nil;
   if sp1=nil then
   begin
      sp1:=sp;
      spk:=sp;
   end
   else
   begin
      spk.a:=sp;
      spk:=sp;
   end;
end;


procedure Tzad.read1;
begin
   sp:=sp1;
   inf:=sp.inf;
   sp1:=sp.a;
   if sp1=nil then
      spk:=nil;
   dispose(sp);
end;



procedure Tzad.sortslip;
   procedure div2sp(tp:Tzad; var tq,tr:Tzad);
   var c:integer; inf:Tinf;
   begin
      tq:=Tzad.create;
      tr:=Tzad.create;
      c:=-1;
      while tp.sp1<>nil do
      begin
         c:=-c;
         tp.read1(inf);
         if c>0 then tq.addk(inf)
         else tr.addk(inf);
      end;
   end;    //div2sp


   procedure slip(tq,tr:Tzad;var tp:Tzad);
   var inf:Tinf;
   begin
      while (tq.sp1<>nil) and(tr.sp1<>nil) do
         if tq.sp1.inf.k>tr.sp1.inf.k then
         begin
            tr.read1(inf);
            tp.addk(inf);
         end
         else
         begin
            tq.read1(inf);
            tp.addk(inf);
         end;

      while tq.sp1<>nil do
      begin
         tq.read1(inf);
         tp.addk(inf);
      end;

      while tr.sp1<>nil do
      begin
         tr.read1(inf);
         tp.addk(inf);
      end;
   end; //slip


   procedure srsl(tp:Tzad);
   var tq,tr:Tzad;
   begin
      if tp.sp1<>tp.spk then
      begin
         div2sp(tp,tq,tr);
         srsl(tq);
         srsl(tr);
         slip(tq,tr,tp);
      end;
   end; //srsl

begin
   srsl(self)
end;

end.
 