unit Unit2;

interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;
  
type

TInf = record
        k: integer;
        f: string;
end;

TCell = ^Cell;
Cell = record
        inf:Tinf;
        A: TCell;
end;

TClass = class(TObject)
        sp,sp1: TCell;
        constructor Create();
        procedure Add(inf:TInf);
        procedure Read(var inf:Tinf);
        procedure Sort();
end;

implementation

constructor TClass.Create();
begin
inherited create();
sp1:=nil;
end;

procedure TClass.Add(inf:Tinf);
begin
New(sp);
sp.inf:=inf;
sp^.A:=sp1;
sp1:=sp;
end;

procedure TClass.Read(var inf:TInf);
begin
inf:=sp1.inf;
sp:=sp1;
sp1:=sp1^.A;
Dispose(sp);
end;

procedure TClass.Sort();
  procedure Rev(spi:TCell);
  var
   n,n2:TCell;
  begin
   n:=spi^.A;
   n2:=spi^.A^.A;
   n^.A:=n2^.A;
   n2^.A:=n;
   spi^.A:=n2;
  end;
var
 spt: TCell;
begin
 spt:=Nil;
 Repeat
  sp:=sp1;
  While sp^.A^.A<>spt do
   begin
    if sp^.A^.Inf.k > sp^.A^.A^.Inf.k then Rev(sp);
    sp:=sp^.A;
   end;
   spt:=sp^.A;
 Until sp1^.A^.A=spt;
end;

end.
