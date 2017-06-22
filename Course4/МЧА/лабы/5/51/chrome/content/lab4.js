var g;
var graph='u';
var scheme='impl';
var tb_tmax;

/*
u_t = a*u_xx + b*u_yy + f(x,t),
u(0,y,t)=fi_1(y,t),
u_x(lx,y,t)=fi_2(y,t),
u(x,0,t)=fi_3(x,t),
u_y(x,ly,t)=fi_4(x,t),
u(x,y,0)=ksi(x,y).
*/


var a;
var b;
var mu;

var method='val_dir';
var cut='y';
var Nx=100;
var Ny=100;
var K=100;
var tau;
var t;
var decimalplaces=3;
var x0=0.0;
var y0=0.0;
var lx=Math.PI;
var ly=Math.PI;
var t0=0.0;
var U=Matrix3(Nx+1,Ny+1);
var omega=1.5;
var log='';
//var nval_dir;

function fi1(y,t)
{
	return 0;
}

function fi2(y,t)
{
	return -Math.sin(y)*Math.sin(mu*t);	
}

function fi3(x,t)
{
	return 0;
}

function fi4(x,t)
{
	return -Math.sin(x)*Math.sin(mu*t);
}

function ksi(x,y)
{
	return 0;
}

function f(x,y,t)
{
	return Math.sin(x)*Math.sin(y)*(mu*Math.cos(mu*t)+(a+b)*Math.sin(mu*t));
}

function U_real(x,y,t)
{
	return Math.sin(x)*Math.sin(y)*Math.sin(mu*t);
}

function Matrix(n,m)
{
	var M=[];
	for (var i=0;i<n;i++)
	{
		M[i]=[];
		for (var j=0;j<m;j++)
			M[i][j]=0;
	}
	return M;
}

function Matrix3(n,m)
{
	var M=[];
	for (var i=0;i<n;i++)
	{
		M[i]=[];
		for (var j=0;j<m;j++)
			M[i][j]=[];
	}
	return M;
}

function onload()
{
	try{
		tb_a=document.getElementById('tb_a');
		tb_b=document.getElementById('tb_b');
		tb_mu=document.getElementById('tb_mu');
		tb_Nx=document.getElementById('tb_Nx');
		tb_Ny=document.getElementById('tb_Ny');
		tb_i=document.getElementById('tb_i');
		tb_j=document.getElementById('tb_j');
		vb_t=document.getElementById('vb_t');
		tb_t=document.getElementById('tb_t');
		tb_tmax=document.getElementById('tb_tmax');
		tb_omega=document.getElementById('tb_omega');
		hb_omega=document.getElementById('hb_omega');
		tb_tau=document.getElementById('tb_tau');
		l_tb1=document.getElementById('l_tb1');
		l_tb2=document.getElementById('l_tb2');
		l_tb3=document.getElementById('l_tb3');
		l_tb_x=document.getElementById('l_tb_x');
		l_tb_y=document.getElementById('l_tb_y');
		
		l_eps=document.getElementById('l_eps');
		//l_nval_dir=document.getElementById('l_nval_dir');
		tb_log=document.getElementById('tb_log');

		vb_eps=document.getElementById('vb_eps');
		vb_msy=document.getElementById('vb_msy');
		hb_cut=document.getElementById('hb_cut');
		vb_i=document.getElementById('vb_i');
		vb_j=document.getElementById('vb_j');
		
		tb_msy=document.getElementById('tb_msy');
		browser=document.getElementById('b_graph');
		
		rb_val_dir=document.getElementById('rb_val_dir');
		rb_frac_steps=document.getElementById('rb_frac_steps');

		canvas=browser.contentDocument.getElementById('graph');
		g=canvas.getContext("2d");
		Nx=parseFloat(tb_Nx.value);
		Ny=parseFloat(tb_Ny.value);
		tb_i.max=Nx;
		tb_j.max=Ny;
		a=parseFloat(tb_a.value);
		b=parseFloat(tb_b.value);
		mu=parseFloat(tb_mu.value);
		t=parseInt(tb_t.value);
		tau=parseFloat(tb_tau.value);
		step_norm();
		
		drawGrid();
	}catch(e){alert(e);}
}

function step_norm()
{
	try{
		hx=lx/Nx;
		hy=ly/Ny;
	}catch(e){alert(e);}
}

function a_change()
{
	try{
		a=parseFloat(tb_a.value);
		step_norm();
	}catch(e){alert(e);}
}

function b_change()
{
	try{
		b=parseFloat(tb_b.value);
		step_norm();
	}catch(e){alert(e);}
}

function mu_change()
{
	try{
		mu=parseFloat(tb_mu.value);
		step_norm();
	}catch(e){alert(e);}
}

function Nx_change()
{
	try{
		Nx=parseFloat(tb_Nx.value);
		tb_i.max=Nx;
	}catch(e){alert(e);}
}

function Ny_change()
{
	try{
		Ny=parseFloat(tb_Ny.value);
		tb_j.max=Ny;
	}catch(e){alert(e);}
}

function tau_change()
{
	try{
		tau=parseFloat(tb_tau.value);
	}catch(e){alert(e);}
}

function t_change()
{
	try{
		t=parseFloat(tb_t.value);
		if (t>K)
		{
			t=K;
			tb_t.value=t;
		}
		draw();
	}catch(e){alert(e);}
}

function tmax_change()
{
	try{
		K=parseInt(tb_tmax.value);
	}catch(e){alert(e);}
}

function omega_change()
{
	try{
		omega=parseFloat(tb_omega.value);
	}catch(e){alert(e);}
}

function i_change()
{
	try{
		draw();
	}catch(e){alert(e);}
}

function j_change()
{
	try{
		draw();
	}catch(e){alert(e);}
}

function rb_x_click()
{
	try{
		cut='x';
		vb_j.hidden=true;
		vb_i.hidden=false;
		draw();
	}catch(e){alert(e);}
}

function rb_y_click()
{
	try{
		cut='y';
		vb_i.hidden=true;
		vb_j.hidden=false;
		draw();
	}catch(e){alert(e);}
}

function ms_change()
{
	try{
		draw();
	}catch(e){alert(e);}
}

function rb_u_click()
{
	try{
		graph='u';
		draw();
	}catch(e){alert(e);}
}

function rb_eps_click()
{
	try{
		graph='eps';
		draw();
	}catch(e){alert(e);}
}

function rb_val_dir_click()
{
	try{
		//hb_omega.hidden=true;
		method='val_dir';
	}catch(e){alert(e);}
}

function rb_frac_steps_click()
{
	try{
		//hb_omega.hidden=true;
		method='frac_steps';
	}catch(e){alert(e);}
}

function solve()
{
	try{
		step_norm();
		init();
		if (method=='val_dir') val_dirSolve();
		if (method=='frac_steps') frac_stepsSolve();
		proto();
		draw();
	}catch(e){alert(e);}
}

function init()
{
	try{
		for (var i=0;i<=Nx;i++)
			for (var j=0;j<=Ny;j++)
				U[i][j][0]=ksi(i*hx,j*hy);
	}catch(e){alert(e);}
}

function val_dirSolve()
{
	try{
		var A=[];
		var B=[];
		var C=[];
		var D=[];
		var P=[];
		var Q=[];
		var A_const;
		var B_const;
		var C_const;
		U12=Matrix(Nx+1,Ny+1);
		for (var k=0;k<K;k++)
		{
			A_const=a/(hx*hx);
			B_const=-2*a/(hx*hx)-2/tau;
			C_const=a/(hx*hx);
			
			for (var j=1;j<Ny;j++)
			{
				for (var i=1;i<Nx;i++)
				{
					A[i]=A_const;
					B[i]=B_const;
					C[i]=C_const;
					D[i]=-b*(U[i][j+1][k]-2*U[i][j][k]+U[i][j-1][k])/(hy*hy) - f(i*hx,j*hy,(k+0.5)*tau) -2*U[i][j][k]/tau;
				}
				A[1]=0;
				D[1]-=fi1(j*hy,(k+0.5)*tau)*a/(hx*hx);
				
				A[Nx]=-1;
				B[Nx]=hx*hx/(a*tau)+1;
				C[Nx]=0;
				D[Nx]=hx*fi2(hy*j,(k+0.5)*tau) + hx*hx*( 2*U[Nx][j][k]/tau +  b*(U[Nx][j+1][k]-2*U[Nx][j][k]+U[Nx][j-1][k])/(hy*hy) + f(Nx*hx, hy*j, (k+0.5)*tau) )/(2*a);
				
				P[1]=-C[1]/B[1];
				Q[1]=D[1]/B[1];
				for (var i=2;i<=Nx;i++)
				{
					P[i]=-C[i]/(B[i]+A[i]*P[i-1]);
					Q[i]=(D[i]-A[i]*Q[i-1])/(B[i]+A[i]*P[i-1]);
				}
				
				U12[Nx][j]=Q[Nx];
				for (var i=Nx-1;i>=1;i--)
					U12[i][j]=P[i]*U12[i+1][j]+Q[i];
				U12[0][j]=fi1(j*hy,(k+0.5)*tau);
			}
			
			for (var i=0;i<=Nx;i++)
			{
				U12[i][0]=fi3(i*hx,(k+0.5)*tau);
				U12[i][Ny]=( 2*hy*fi4(i*hx,(k+0.5)*tau) - U12[i][Ny-2] + 4*U12[i][Ny-1] )/3;
			}
			
			A_const=b/(hy*hy);
			B_const=-2*b/(hy*hy)-2/tau;
			C_const=b/(hy*hy);
			
			for (var i=1;i<Nx;i++)
			{
				for (var j=1;j<Ny;j++)
				{
					A[j]=A_const;
					B[j]=B_const;
					C[j]=C_const;
					D[j]=-a*(U12[i+1][j]-2*U12[i][j]+U12[i-1][j])/(hx*hx) - f(i*hx,j*hy,(k+0.5)*tau) -2*U12[i][j]/tau;
				}
				A[1]=0;
				D[1]-=fi3(i*hx,(k+1)*tau)*b/(hy*hy);
				
				A[Ny]=-1;
				B[Ny]=hy*hy/(b*tau)+1;
				C[Ny]=0;
				D[Ny]=hy*fi4(hx*i,(k+1)*tau) + hy*hy*( 2*U12[i][Ny]/tau +  a*(U12[i][Ny]-2*U12[i][Ny]+U12[i][Ny])/(hx*hx) + f(i*hx, Ny*hy, (k+0.5)*tau) )/(2*b);
				
				P[1]=-C[1]/B[1];
				Q[1]=D[1]/B[1];
				for (var j=2;j<=Ny;j++)
				{
					P[j]=-C[j]/(B[j]+A[j]*P[j-1]);
					Q[j]=(D[j]-A[j]*Q[j-1])/(B[j]+A[j]*P[j-1]);
				}
				
				U[i][Ny][k+1]=Q[Ny];
				for (var j=Ny-1;j>=1;j--)
					U[i][j][k+1]=P[j]*U[i][j+1][k+1]+Q[j];
				U[i][0][k+1]=fi3(i*hx,(k+1)*tau);
			}
			
			for (var j=0;j<=Ny;j++)
			{
				U[0][j][k+1]=fi1(i*hx,(k+1)*tau);
				U[Nx][j][k+1]=( 2*hx*fi2(j*hy,(k+1)*tau) - U[Nx-2][j][k+1] + 4*U[Nx-1][j][k+1] )/3;
			}
			
		}
		
	}catch(e){alert(e);}
}

function frac_stepsSolve()
{
	try{
		var A=[];
		var B=[];
		var C=[];
		var D=[];
		var P=[];
		var Q=[];
		var A_const;
		var B_const;
		var C_const;
		U12=Matrix(Nx+1,Ny+1);
		for (var k=0;k<K;k++)
		{
			A_const=a/(hx*hx);
			B_const=-2*a/(hx*hx)-1/tau;
			C_const=a/(hx*hx);
			
			for (var j=1;j<Ny;j++)
			{
				for (var i=1;i<Nx;i++)
				{
					A[i]=A_const;
					B[i]=B_const;
					C[i]=C_const;
					D[i]=- f(i*hx,j*hy,k*tau)/2 -U[i][j][k]/tau;
				}
				A[1]=0;
				D[1]-=fi1(j*hy,k*tau)*a/(hx*hx);
				
				A[Nx]=-1;
				B[Nx]=hx*hx/(2*a*tau)+1;
				C[Nx]=0;
				D[Nx]=hx*fi2(hy*j,(k+0.5)*tau) + hx*hx*( U[Nx][j][k]/tau + f(Nx*hx, hy*j, k*tau)/2 )/(2*a);
				
				P[1]=-C[1]/B[1];
				Q[1]=D[1]/B[1];
				for (var i=2;i<=Nx;i++)
				{
					P[i]=-C[i]/(B[i]+A[i]*P[i-1]);
					Q[i]=(D[i]-A[i]*Q[i-1])/(B[i]+A[i]*P[i-1]);
				}
				
				U12[Nx][j]=Q[Nx];
				for (var i=Nx-1;i>=1;i--)
					U12[i][j]=P[i]*U12[i+1][j]+Q[i];
				U12[0][j]=fi1(j*hy,(k+0.5)*tau);
			}
			
			for (var i=0;i<=Nx;i++)
			{
				U12[i][0]=fi3(i*hx,(k+0.5)*tau);
				U12[i][Ny]=( 2*hy*fi4(i*hx,(k+0.5)*tau) - U12[i][Ny-2] + 4*U12[i][Ny-1] )/3;
			}
			
			A_const=b/(hy*hy);
			B_const=-2*b/(hy*hy)-1/tau;
			C_const=b/(hy*hy);
			
			for (var i=1;i<Nx;i++)
			{
				for (var j=1;j<Ny;j++)
				{
					A[j]=A_const;
					B[j]=B_const;
					C[j]=C_const;
					D[j]=- f(i*hx,j*hy,(k+1)*tau)/2 -U12[i][j]/tau;
				}
				A[1]=0;
				D[1]-=fi3(i*hx,(k+1)*tau)*b/(hy*hy);
				
				A[Ny]=-1;
				B[Ny]=hy*hy/(2*b*tau)+1;
				C[Ny]=0;
				D[Ny]=hy*fi4(hx*i,(k+1)*tau) + hy*hy*( U12[i][Ny]/tau + f(i*hx, Ny*hy, (k+1)*tau)/2 )/(2*b);
				
				P[1]=-C[1]/B[1];
				Q[1]=D[1]/B[1];
				for (var j=2;j<=Ny;j++)
				{
					P[j]=-C[j]/(B[j]+A[j]*P[j-1]);
					Q[j]=(D[j]-A[j]*Q[j-1])/(B[j]+A[j]*P[j-1]);
				}
				
				U[i][Ny][k+1]=Q[Ny];
				for (var j=Ny-1;j>=1;j--)
					U[i][j][k+1]=P[j]*U[i][j+1][k+1]+Q[j];
				U[i][0][k+1]=fi3(i*hx,(k+1)*tau);
			}
			
			for (var j=0;j<=Ny;j++)
			{
				U[0][j][k+1]=fi1(i*hx,(k+1)*tau);
				U[Nx][j][k+1]=( 2*hx*fi2(j*hy,(k+1)*tau) - U[Nx-2][j][k+1] + 4*U[Nx-1][j][k+1] )/3;
			}
			
		}
	}catch(e){alert(e);}
}

function draw()
{
	try{
		drawGrid();
		if (graph=='u')
		{
			if (cut=='y')
			{
				j=parseInt(document.getElementById('tb_j').value);
				drawUy(j, "red");
				drawRealUy(j, "green");
				l_eps.value='  \u03B5 = '+epsY(j).toFixed(4);
				vb_j.hidden=false;
			} else
			{
				i=parseInt(document.getElementById('tb_i').value);
				drawUx(i, "red");
				drawRealUx(i, "green");
				l_eps.value='  \u03B5 = '+epsX(i).toFixed(4);
				vb_i.hidden=false;
			}
			//l_nval_dir.value='  '+nval_dir.toString();
			hb_cut.hidden=false;
			vb_eps.hidden=false;
			vb_t.hidden=false;
			vb_msy.hidden=true;
		} else
		{
			vb_j.hidden=true;
			vb_i.hidden=true;
			hb_cut.hidden=true;
			vb_eps.hidden=true;
			vb_msy.hidden=false;
			vb_t.hidden=true;
			drawEps(t, "red");
		}
	}catch(e){alert(e);}
}

function proto()
{
	try{
		log='Nx = '+ Nx+'\n';
		log+='  hx = '+ hx+'\n';
		log+='Ny = '+ Ny+'\n';
		log+='  hy = '+ hy+'\n';
		log+='  t = '+ t+'\n';
		log+='method = '+ method+'\n';
		log+='\n\n';
		log+='Eps = '+epsT(t);
		log+='\n\n\n';
		if (cut=='y')
			for (var j=0;j<=Ny;j++)
			{
				log+='y = ' +hy*j+ '\n';
				log+='u(x,y):\n';
				for (var i=0;i<=Nx;i++)
					log+=U[i][j][t].toFixed(4)+' ';
				log+='\n\n\n';
			}
		else
			for (var i=0;i<=Nx;i++)
			{
				log+='x = ' +hx*i+ '\n';
				log+='u(x,y):\n';
				for (var j=0;j<=Ny;j++)
					log+=U[i][j][t].toFixed(4)+' ';
				log+='\n\n\n';
			}
		tb_log.value=log;
		log='';
	}catch(e){alert(e);}
}

function epsRes()
{
	try{
		var max=0.0;
		for (var i=0;i<=Nx;i++)
			for (var j=0;j<=Ny;j++)
				if (Math.abs(U[i][j][t]-U_real(hx*i,hy*j, tau*t))>max)
					max=Math.abs(U[i][j][t]-U_real(hx*i,hy*j, tau*t));
		return max;
	}catch(e){alert(e);}
}

function epsY(j)
{
	try{
		var max=0.0;
		for (var i=0;i<=Nx;i++)
			if (Math.abs(U[i][j][t]-U_real(hx*i,hy*j, tau*t))>max)
				max=Math.abs(U[i][j][t]-U_real(hx*i,hy*j, tau*t));
		return max;
	}catch(e){alert(e);}
}

function epsX(i)
{
	try{
		var max=0.0;
		for (var j=0;j<=Ny;j++)
			if (Math.abs(U[i][j][t]-U_real(hx*i,hy*j, tau*t))>max)
				max=Math.abs(U[i][j][t]-U_real(hx*i,hy*j, tau*t));
		return max;
	}catch(e){alert(e);}
}

function epsT(t)
{
	try{
		var max=0.0;
		for (var i=0;i<=Nx;i++)
			for (var j=0;j<=Ny;j++)
				if (Math.abs(U[i][j][t]-U_real(hx*i,hy*j, tau*t))>max)
					max=Math.abs(U[i][j][t]-U_real(hx*i,hy*j, tau*t));
		return max;
	}catch(e){alert(e);}
}

var X=450;
var Y=384;
var X0=parseInt(X/4);
var Y0=parseInt(5*Y/6);
var st_x=10;
var st_y=10;

function drawGrid()
{
	try{
		canvas.width=X;
		canvas.height=Y;
		g.lineWidth = 2;
		g.strokeStyle = "black";
		g.moveTo(X0,0);
		g.lineTo(X0,Y);
		g.moveTo(0,Y0);
		g.lineTo(X,Y0);
		
		g.moveTo(X0,0);
		g.lineTo(X0+2,10);
		g.moveTo(X0,0);
		g.lineTo(X0-2,10);
		g.moveTo(X,Y0);
		g.lineTo(X-10,Y0+2);
		g.moveTo(X,Y0);
		g.lineTo(X-10,Y0-2);
		g.stroke();
		var msy=parseFloat(tb_msy.value);
		if ((graph=='eps')&&(msy>1))
		{
			l_tb3.value=(1/msy).toFixed(4);
			l_tb3.setAttribute("style","color:#880000; top:"+(Y0-10*st_y)+"px;left:"+(X0-5-7*(l_tb3.value.length-1))+"px;");
		}
		else
		{
			l_tb3.value="1";
			l_tb3.setAttribute("style","color:#880000; top:"+(Y0-10*st_y)+"px;left:"+(X0-8)+"px;");
		}
		
		if (graph=='u')
		{
			l_tb_y.value="U";
			if (cut=='y')
				l_tb_x.value="x";
			else
				l_tb_x.value="y";
			l_tb2.value="1";
		}
		else
		{
			l_tb_y.value="Eps";
			l_tb_x.value="t";
			l_tb2.value="100";
		}	
		
		l_tb_x.setAttribute("style","color:#880000; top:"+(Y0+8)+"px;left:"+(X-10)+"px;");
		l_tb_y.setAttribute("style","color:#880000; top:"+(10)+"px;left:"+(X0-8-7*(l_tb_y.value.length-1))+"px;");
		
		l_tb1.value="0";
		l_tb1.setAttribute("style","color:#880000; top:"+(Y0+8)+"px;left:"+(X0-8)+"px;");
		l_tb2.setAttribute("style","color:#880000; top:"+(Y0+8)+"px;left:"+(X0+10*st_x)+"px;");
		
		//l_tb1.style="top:100px;";
		//l_tb1.style.left=X0.toString()+"px;";
		
		var x=X0;
		var l;
		
		for (var i=0;x<X-10;i++)
		{
			if (i%10==0) l=10;
			else
				if (i%5==0) l=8;
					else l=5;
			g.moveTo(x,Y0);
			g.lineTo(x,Y0-l);
			x+=st_x;
		}
		x=X0;
		for (var i=0;x>0;i++)
		{
			if (i%10==0) l=10;
			else
				if (i%5==0) l=8;
					else l=5;
			g.moveTo(x,Y0);
			g.lineTo(x,Y0-l);
			x-=st_x;
		}
		
		var y=Y0;
		for (var i=0;y<Y-10;i++)
		{
			if (i%10==0) l=10;
			else
				if (i%5==0) l=8;
					else l=5;
			g.moveTo(X0,y);
			g.lineTo(X0+l,y);
			y+=st_y;
		}
		y=Y0;
		for (var i=0;y>0;i++)
		{
			if (i%10==0) l=10;
			else
				if (i%5==0) l=8;
					else l=5;
			g.moveTo(X0,y);
			g.lineTo(X0+l,y);
			y-=st_y;
		}
		g.stroke();
		g.beginPath();
		g.closePath();
	}catch(e){alert(e);}
}

function drawUy(j, cl)
{
	try{
		var g=canvas.getContext("2d");
		g.closePath();
		g.lineWidth = 1;
		g.moveTo(X0, Y0-U[0][j][t]*10*st_y);
		for (var i=1;i<=Nx;i++)
			g.lineTo(X0+(x0+i*hx)*(10*st_x), Y0-U[i][j][t]*(10*st_y));
		g.strokeStyle = cl;
		g.stroke();
		g.beginPath();
		g.closePath();
	}catch(e){alert(e);}
}

function drawUx(i, cl)
{
	try{
		var g=canvas.getContext("2d");
		g.closePath();
		g.lineWidth = 1;
		g.moveTo(X0, Y0-U[i][0][t]*10*st_y);
		for (var j=1;j<=Ny;j++)
			g.lineTo(X0+(j*hy)*(10*st_x), Y0-U[i][j][t]*(10*st_y));
		g.strokeStyle = cl;
		g.stroke();
		g.beginPath();
		g.closePath();
	}catch(e){alert(e);}
}

function drawRealUy(j, cl)
{
	try{
		var g=canvas.getContext("2d");
		g.closePath();
		g.lineWidth = 1;
		g.moveTo(X0, Y0-U_real(x0, j*hy, tau*t)*10*st_y);
		for (var i=1;i<=Nx;i++)
			g.lineTo(X0+(x0+i*hx)*(10*st_x), Y0-U_real(x0+i*hx, j*hy, tau*t)*(10*st_y));
		g.strokeStyle = cl;
		g.stroke();
		g.beginPath();
		g.closePath();
	}catch(e){alert(e);}
}

function drawRealUx(i, cl)
{
	try{
		var g=canvas.getContext("2d");
		g.closePath();
		g.lineWidth = 1;
		g.moveTo(X0, Y0-U_real(i*hx, 0, tau*t)*10*st_y);
		for (var j=1;j<=Ny;j++)
			g.lineTo(X0+(x0+j*hy)*(10*st_x), Y0-U_real(i*hx, j*hy, tau*t)*(10*st_y));
		g.strokeStyle = cl;
		g.stroke();
		g.beginPath();
		g.closePath();
	}catch(e){alert(e);}
}

function drawEps(t, cl)
{
	try{
		var msy=parseInt(tb_msy.value);
		var g=canvas.getContext("2d");
		g.closePath();
		g.lineWidth = 1;
		g.moveTo(X0, Y0);
		for (var t=1;t<=K;t++)
			g.lineTo(X0+t*(0.1*st_x), Y0-epsT(t)*(100*st_y)*msy);
		g.strokeStyle = cl;
		g.stroke();
		g.beginPath();
		g.closePath();
	}catch(e){alert(e);}
}

