.MODEL small
.386
.STACK 100h
.DATA
 step dq 0.01  ;инкрементарная величина угла
 R dw 10        ;константа для ввода
 
 offsetY dw 0 ; смещение по оси Y
 offsetX dw 0 ; смещение по оси X
 
 a dw 0          ;горизонтальный радиус
 b dw 0          ;вертикальный радиус
 tmp dw ?      ;величина для промежуточных вычислений 
 t dq 750.0          ;угол поворота
 opa dq 750.0          ;угол поворота
 ;;;;;;;;;;менять угол
 message1 db  0dh,'Enter A :  $'       
 message2 db  0ah,0dh, 'Enter B: $'
.CODE


 
 Circle proc
 next: 
 push cx         ;помещение числа итераций в стек из сх

 fld t          ;вещественное помещение t в стек сопроцессора
 fld t          ;да еще раз; st(0) = st(1) = t
 fsin          ;st(0) = sin(t), st(1) = t     
 fild b        ;st(0) = b, st(1) = sin (t), st(2) = t
 fmul         ;st(0) = b*sin(t), st(1) = t
 fistp tmp        ;целочисленное изъятие st(0) -> tmp
 mov dx, tmp   ;координата у
 add dx, offsetY    ;середина экрана (по вертикали)
 
 fcos         ;st(0) = cos(t)
 fild a        ;st(0) = a, st(1) = cos(t)
 fmul         ;st(0) = a*cos(t)
 fistp tmp
 mov cx, tmp   ;координата х
 add cx, offsetX    ;середина экрана (по горизонтали)

 mov ah, 0ch   ;рисование точки
 mov al, 1     ;цвет (синий)
 int 10h

 fld t           ;st(0) = t
 fld step      ;st(0) = step, st(1) = t
 fadd           ;st(0) = step + t
 fstp t          ;t = step + t

 pop cx        ;забираем число итераций из стека в сх
 loop next
 ret
 ENDP Circle
start:
 mov ax, @data
 mov ds, ax 
 
 mov al, 12h    ;видеорежим 640*480
 xor ah, ah     
 int 10h   
 
 finit  ;инициализация сопроцессора
 
 mov cx, 500    ;число итераций (обусловлено шагом 0.01)
  mov a, 200
 mov b, 100;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;; 
mov	offsetY, 240
mov offsetX, 320
call Circle  ; рисует верхнюю дугу

mov cx, 500  
mov	offsetY, 260
push opa
pop t
call Circle ; рисует нижнюю дугу

 mov a, 11
 mov b, 11
 
mov cx, 629  
mov	offsetY, 335
mov offsetX, 423
push opa
pop t
call Circle ; круг внизу справа  

mov cx, 629
mov	offsetY, 324
mov offsetX, 187
push opa
pop t
call Circle ; круг внизу слева

mov cx, 629
mov	offsetY, 165
mov offsetX, 423
push opa
pop t
call Circle ; круг вверху справа

mov cx, 629
mov a, 9
 mov b, 9
mov	offsetY, 303
mov offsetX, 150
push opa
pop t
call Circle ; круг вверху слевац

mov cx, 629
mov a, 9
 mov b, 9
mov	offsetY, 280
mov offsetX, 140
push opa
pop t
call Circle ; круг вверху слевац

 
mov ah, 1    ;Функция захвата кода клавиши (идентична getch из "с")
 int 21h
 mov ah, 4ch ;корректный выход
 int 21h

end start