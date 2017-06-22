unit Unit2;

interface
uses  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
      Dialogs, StdCtrls;

Type
TInf = record
  f: shortstring;
  k: word;
end;

TStack = ^Stack;
Stack = record
  inf: TInf;
  A: TStack;
end;

TClass = class(TObject)
   sp,sp1,spk: TStack;
   constructor Create();
   procedure Addk(inf: TInf);
   procedure Read1(var inf: TInf);
   procedure Sort();
end;

implementation

constructor TClass.Create();
begin
sp1:=nil;
spk:=nil;
end;

procedure TClass.Addk(inf: TInf);
begin
    if sp1<>nil then
      begin
        new(sp);
        sp.inf:=inf;
        spk.A:=sp;
        sp.A:=nil;
        spk:=sp;
      end
    else
      begin
        new(sp);
        sp.inf:=inf;
        sp.A:=nil;
        sp1:=sp;
        spk:=sp;
      end;
end;

procedure TClass.Read1(var inf:TInf);
begin
inf:=sp1.inf;
sp:=sp1;
sp1:=sp.A;
dispose(sp);
end;

procedure TClass.Sort();

Procedure Slip(tq,tr,tp:TClass);
  Var Inf:TInf;
    Begin
      While(tq.sp1<>Nil) and (tr.sp1<>Nil) do
    	  if tq.sp1.Inf.k<tr.sp1.Inf.k then
          begin
            tq.Read1(Inf);
            tp.Addk(Inf)
          end
       else
         begin
           tr.Read1(Inf);
           tp.Addk(Inf)
         end;

   while tq.sp1<>nil do
     begin
       tq.Read1(Inf);
       tp.Addk(Inf);
     end;

   while tr.sp1<>nil do
     begin
       tr.Read1(Inf);
       tp.Addk(Inf);
     end;
 end;

Procedure Div2sp(tp:TClass; var tq,tr:TClass);
Var Inf:TInf;
    C:shortint;
  begin
    tq:=TClass.create;
    tr:=TClass.create;
    c:=-1;
    While tp.sp1<>Nil do
      begin
        c:=-c;
        tp.Read1(Inf);
        If C>0 then tq.Addk(Inf)
        else tr.Addk(Inf);
      end;
 end;

Procedure Srsl(var tp:TClass);
Var tq,tr:TClass;
  begin
    if tp.sp1<>tp.spk then
      begin
        Div2sp(tp,tq,tr);
        Srsl(tq);
        Srsl(tr);
        slip(tq,tr,tp);
			end;
  end;
begin
  Srsl(self);
end;

end.

