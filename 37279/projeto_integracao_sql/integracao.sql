drop schema if exists integracao;
create schema integracao;
use integracao;

create table produto
(
	cd_produto int,
	nm_produto varchar (255),
	vl_produto decimal (10,2),
	constraint pk_produto primary key (cd_produto)

); 

insert into produto values(1,'Coca Cola 2L',15.00);
insert into produto values(2,'Coxinha',6.00);

select * from produto;
select max(cd_produto) from produto;
select * from produto;