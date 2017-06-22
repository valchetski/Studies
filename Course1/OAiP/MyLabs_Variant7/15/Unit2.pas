unit Unit2;

interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;
Type
Tsel=^sel;
TInf=record
  I1:string;
  key:integer;
end;

Sel=record
  inf:Tinf;
  A:Tsel;
end;

TStack=class(tobject)
  procedure Adds(Inf:Tinf );
  procedure Add1(Inf:Tinf );
  procedure Add2(Inf:Tinf );
  procedure Reads(var Inf:Tinf );
  procedure Print(Memo:Tmemo;sp1:tsel);
  procedure AddAfter(spi:Tsel; Inf:Tinf );
  procedure ReadAfter(spi:tsel; var Inf:Tinf );
  function Poisk(K:integer):Tsel;
  Function PoiskAfter(k:integer):Tsel;
  Procedure SortBublInf;
  Procedure SortBublAfter;
end;
Tzad=class(Tstack)
  constructor create;
  procedure resh(sp1:tsel; var p2,p3:tsel );
end;
var n,m:word; b,inf:Tinf; sp,sp1,sp2,sp3:Tsel;
implementation

constructor Tzad.create;
begin
inherited create;
sp1:=nil;
end;

procedure Tstack.Adds;
begin
  New(sp);
  sp^.inf:=inf;
  sp^.A:=sp1;
  sp1:=sp;
end;

procedure Tstack.Add1;
var sp:tsel;
begin
  New(sp);
  sp^.inf:=inf;
  sp^.A:=sp2;
  sp2:=sp;
end;

procedure Tstack.Add2;
var sp:tsel;
begin
  New(sp);
  sp^.inf:=inf;
  sp^.A:=sp3;
  sp3:=sp;
end;

procedure Tstack.Reads;
begin
  inf:=sp1^.inf;
  sp:=sp1;
  sp1:=sp1^.A;
  Dispose(sp);
end;

procedure Tstack.Print;
begin
  Memo.Clear;
  sp:=sp1;
  While sp<>nil do begin;
    Memo.Lines.Add(IntTostr(sp^.inf.key)+'  '+Sp^.inf.I1);
    sp:=sp^.A;
  end;
end;

procedure Tstack.AddAfter;
begin
  New(sp);
  Sp^.inf:=inf;
  sp^.A:=spi^.A;
  spi^.A:=sp;
end;

procedure Tstack.ReadAfter;
begin
  sp:=spi^.A;
  inf:=sp^.inf;
  spi^.A:=sp^.A;
  dispose(sp);
end;

Function Tstack.Poisk;
begin
  if sp1=Nil then Result:=nil else
    begin
      sp:=sp1;
      while (sp^.inf.key <>K) and (sp^.a<>nil) do Sp:=sp^.A;
      if sp^.inf.key<>K then  result:=nil else
        begin
          result:=sp;
          Inf:=sp^.inf;
        end;
    end;
end;


Function Tstack.PoiskAfter;
begin
  if sp1^.a=nil then Result:=Nil else
  begin
    sp:=sp1;
    While(sp^.A^.inf.key<>k) and (sp^.A^.A<>nil) do sp:=sp^.A;
    if sp^.A.inf.key<>k then Result:=nil
    else Result:=sp;
  end;
end;

Procedure Tstack.SortBublInf;
  procedure RevInf(spi:Tsel);
    var inf:Tinf;
  begin
    inf:=sp^.inf;
    sp^.inf:=sp^.A^.inf;
    sp^.A^.inf:=inf;
  end;
  var spt:Tsel;
begin
  spt:=nil;
  repeat
    sp:=sp1;
    while sp^.A<>spt do begin
      if sp^.Inf.key>sp^.A^.inf.key then RevInf(sp);
      sp:=sp^.a;
    end;
    spt:=sp;
  until sp1^.A=spt;
end;

Procedure TStack.SortBublAfter;
  Procedure RevAfter(spi:Tsel);
    var sp:tsel;
  begin
    sp:=spi^.A^.A;
    spi^.A^.A:=sp^.A;
    sp^.A:=spi^.A;
    spi^.A:=sp;
  end;
  Var spt:Tsel;
begin
  spt:=Nil;
  Repeat
    sp:=sp1;
    While sp^.A^.A<>spt do begin
      if sp^.A^.Inf.key mod 2=1 then RevAfter(sp);
      sp:=sp^.A;
    end;
    spt:=sp^.A;
  Until sp1^.A^.A=spt;
end;

procedure Tzad.resh;
  var qw:tsel; a:integer;
begin
  sp:=sp1;
  qw:=nil;
  if sp^.a<>nil then
    begin
      if sp^.inf.key>0 then Add1(sp^.inf)
      else Add2(sp^.inf);
      resh(sp^.a,p2,p3);
    end
  else
    begin
      if sp^.inf.key<0 then Add1(sp^.inf)
      else Add2(sp^.inf);
    end;
end;
end.
