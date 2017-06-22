%Задание 4. Исследование знакопеременного ряда на сходимость. Признак
%Лейбница
syms p n leibniz_limit an an_diff
is_converges = false;%если is_converges = true тогда ряд сходится
an = cos(n) / (n*n);
p = limit(abs(subs(an, n, n + 1)/an),n,inf);%Признак Д'Аламбера
if(p == 1)
    p = int(abs(an),1,inf);%Интегральный признак
    if(p ~= inf)    
        disp('Ряд сходится абсолютно');
        is_converges = true;
    end;
elseif(p < 1)
    disp('Ряд сходится абсолютно');
    is_converges = true;
end;
if(is_converges == false) 
    an_diff = diff(abs(an), n);
    assume(n>=1);
    if(isAlways(an_diff<0))%Проверка на монотонное убывание
        leibniz_limit = limit(abs(an),n,inf);
        if(leibniz_limit == 0)
            disp('Ряд сходится условно');
        else
            disp('Ряд расходится');
        end;
    else
        disp('Ряд расходится');
    end;
end;