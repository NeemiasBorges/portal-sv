’:
fC:\Users\ifspn\OneDrive\Desktop\APPS\backend-portal-sv\backend-portal-sv\Infra\Utils\StorageHandler.cs
	namespace 	
Infra
 
. 
Utils 
{ 
public 

class 
StorageHandler 
:  !
IStorageHandler" 1
{		 
private

 
readonly

 
string

 
_connectionString

  1
;

1 2
private 
readonly 
string 
_containerName  .
;. /
private 
readonly 
string 
	_blobName  )
;) *
public 
StorageHandler 
( 
IConfiguration ,
conf- 1
)1 2
{ 	
_connectionString 
= 
conf  $
[$ %
$str% D
]D E
??F H
$strI K
;K L
_containerName 
= 
conf !
[! "
$str" >
]> ?
??@ B
$strC E
;E F
	_blobName 
= 
conf 
[ 
$str 4
]4 5
??6 8
$str9 F
;F G
} 	
public 
async 
Task 
< 

Dictionary $
<$ %
string% +
,+ ,
DestinoInfo- 8
>8 9
>9 :%
LerDestinosDoArquivoAsync; T
(T U
stringU [
filePath\ d
)d e
{ 	
var 

blobClient 
= 
new  
BlobContainerClient! 4
(4 5
_connectionString5 F
,F G
_containerNameH V
)V W
. 
GetBlobClient 
( 
	_blobName (
)( )
;) *

Dictionary 
< 
string 
, 
DestinoInfo *
>* +
destinos, 4
=5 6
new7 :

Dictionary; E
<E F
stringF L
,L M
DestinoInfoN Y
>Y Z
(Z [
)[ \
;\ ]
var 
response 
= 
await  

blobClient! +
.+ ,
DownloadAsync, 9
(9 :
): ;
;; <
using 
var 
streamReader "
=# $
new% (
StreamReader) 5
(5 6
response6 >
.> ?
Value? D
.D E
ContentE L
)L M
;M N
var 
content 
= 
await 
streamReader  ,
., -
ReadToEndAsync- ;
(; <
)< =
;= >
var 
linhas 
= 
content  
.  !
Split! &
(& '
$char' +
)+ ,
;, -
foreach!! 
(!! 
var!! 
linha!! 
in!! !
linhas!!" (
.!!( )
Skip!!) -
(!!- .
$num!!. /
)!!/ 0
)!!0 1
{"" 
var## 
partes## 
=## 
linha## "
.##" #
Split### (
(##( )
$char##) ,
,##, -
StringSplitOptions##. @
.##@ A
RemoveEmptyEntries##A S
)##S T
.$$ 
Select$$ 
($$ 
p$$ 
=>$$  
p$$! "
.$$" #
Trim$$# '
($$' (
)$$( )
)$$) *
.%% 
ToArray%% 
(%% 
)%% 
;%% 
if'' 
('' 
partes'' 
.'' 
Length'' !
==''" $
$num''% &
)''& '
{(( 
continue)) 
;)) 
}** 
string,, 
nome,, 
=,, 
partes,, $
[,,$ %
$num,,% &
],,& '
;,,' (
if-- 
(-- 
decimal-- 
.-- 
TryParse-- $
(--$ %
partes--% +
[--+ ,
$num--, -
]--- .
,--. /
out--0 3
var--4 7
precoPorPessoa--8 F
)--F G
&&--H J
decimal.. 
... 
TryParse.. $
(..$ %
partes..% +
[..+ ,
$num.., -
]..- .
,... /
out..0 3
var..4 7 
multiplicadorFamilia..8 L
)..L M
&&..N P
decimal// 
.// 
TryParse// $
(//$ %
partes//% +
[//+ ,
$num//, -
]//- .
,//. /
out//0 3
var//4 7
multiplicadorIdade//8 J
)//J K
&&//L N
decimal00 
.00 
TryParse00 $
(00$ %
partes00% +
[00+ ,
$num00, -
]00- .
,00. /
out000 3
var004 7
multiplicadorSaude008 J
)00J K
)00K L
{11 
destinos22 
[22 
nome22 !
]22! "
=22# $
new22% (
DestinoInfo22) 4
(224 5
precoPorPessoa33 &
,33& ' 
multiplicadorFamilia44 ,
,44, -
multiplicadorIdade55 *
,55* +
multiplicadorSaude66 *
)77 
;77 
}88 
}99 
return:: 
destinos:: 
;:: 
};; 	
public== 
async== 
Task== 
<== 
string==  
>==  !+
GetPrecosParaTodosDestinosAsync==" A
(==A B
)==B C
{>> 	
StringBuilder?? 
context?? !
=??" #
new??$ '
StringBuilder??( 5
(??5 6
)??6 7
;??7 8
var@@ 
destinos@@ 
=@@ 
await@@  %
LerDestinosDoArquivoAsync@@! :
(@@: ;
string@@; A
.@@A B
Empty@@B G
)@@G H
;@@H I
ifBB 
(BB 
destinosBB 
==BB 
nullBB  
||BB! #
destinosBB$ ,
.BB, -
CountBB- 2
==BB3 5
$numBB6 7
)BB7 8
returnCC 
$strCC F
;CCF G
foreachEE 
(EE 
varEE 
destinoEE  
inEE! #
destinosEE$ ,
)EE, -
{FF 
varGG 
nomeDestinoGG 
=GG  !
destinoGG" )
.GG) *
KeyGG* -
;GG- .
varHH 
destinoInfoHH 
=HH  !
destinoHH" )
.HH) *
ValueHH* /
;HH/ 0
contextII 
.II 
AppendII 
(II 
$"II !
$strII! ,
{II, -
nomeDestinoII- 8
}II8 9
$strII9 <
"II< =
)II= >
;II> ?
contextJJ 
.JJ 
AppendJJ 
(JJ 
$"JJ !
$strJJ! 8
{JJ8 9
destinoInfoJJ9 D
.JJD E
PrecoPorPessoaJJE S
:JJS T
$strJJT V
}JJV W
$strJJW Z
"JJZ [
)JJ[ \
;JJ\ ]
}KK 
returnLL 
contextLL 
.LL 
ToStringLL #
(LL# $
)LL$ %
;LL% &
}MM 	
}NN 
}OO ∞	
zC:\Users\ifspn\OneDrive\Desktop\APPS\backend-portal-sv\backend-portal-sv\Infra\Repository\Interfaces\IClienteRepository.cs
	namespace 	
Infra
 
. 

Repository 
. 

Interfaces %
{ 
public 

	interface 
IClienteRepository '
{ 
Task 
Add 
( 
Cliente 
cliente  
)  !
;! "
Task 
< 
List 
< 
Cliente 
> 
> 
GetAll "
(" #
int# &
numero_pagina' 4
,4 5
int6 9
quantidade_p_pagina: M
)M N
;N O
Task		 
Delete		 
(		 
Cliente		 
cliente		 #
)		# $
;		$ %
Task

 
Update

 
(

 
Cliente

 
cliente

 #
)

# $
;

$ %
Task 
< 
Cliente 
> 
Get 
( 
int 
id  
)  !
;! "
} 
} ﬂ
zC:\Users\ifspn\OneDrive\Desktop\APPS\backend-portal-sv\backend-portal-sv\Infra\Repository\Interfaces\IChatbotRepository.cs
	namespace 	
Infra
 
. 

Repository 
. 

Interfaces %
{ 
public 

	interface 
IChatbotRepository '
{ 
Task 
< 
string 
> 
SendMessageAsync %
(% &
string& ,
userMessage- 8
)8 9
;9 :
Task 
< 
string 
> 
CreateChatPrompt %
(% &
string& ,
userMessage- 8
,8 9
string: @
destinationPricesA R
)R S
;S T
void		 
ConfigureHttpClient		  
(		  !
)		! "
;		" #
object

  
CreateRequestPayload

 #
(

# $
string

$ *
prompt

+ 1
)

1 2
;

2 3
Task 
< 
string 
> 
HandleResponseAsync (
(( )
HttpResponseMessage) <
response= E
)E F
;F G
Task 
CriaHistorico 
( 
Chat 
chat  $
)$ %
;% &
Task 
AtualizaHistorico 
( 
Chat #
chat$ (
)( )
;) *
Task 
< 
List 
< 
Chat 
> 
> 
PegaHistoricos '
(' (
)( )
;) *
Task 
< 
int 
> !
validaCategoriaComLLM '
(' (
string( .
resumoConversa/ =
)= >
;> ?
} 
} ¸
rC:\Users\ifspn\OneDrive\Desktop\APPS\backend-portal-sv\backend-portal-sv\Infra\Utils\Interfaces\IStorageHandler.cs
	namespace 	
Infra
 
. 
Utils 
{ 
public 

	interface 
IStorageHandler $
{ 
Task 
< 

Dictionary 
< 
string 
, 
DestinoInfo  +
>+ ,
>, -%
LerDestinosDoArquivoAsync. G
(G H
stringH N
filePathO W
)W X
;X Y
Task 
< 
string 
> +
GetPrecosParaTodosDestinosAsync 4
(4 5
)5 6
;6 7
}		 
}

 À#
nC:\Users\ifspn\OneDrive\Desktop\APPS\backend-portal-sv\backend-portal-sv\Infra\Repository\ClienteRepository.cs
	namespace 	
Infra
 
. 

Repository 
{ 
public		 

class		 
ClienteRepository		 "
:		# $
IClienteRepository		% 7
{

 
private 
readonly 
ConnectionContext *
_context+ 3
;3 4
public 
ClienteRepository  
(  !
ConnectionContext! 2
context3 :
): ;
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
Add 
( 
Cliente %
cliente& -
)- .
{ 	
await 
_context 
. 
Clientes #
.# $
AddAsync$ ,
(, -
cliente- 4
)4 5
;5 6
await 
_context 
. 
SaveChangesAsync +
(+ ,
), -
;- .
} 	
public 
async 
Task 
Delete  
(  !
Cliente! (
cliente) 0
)0 1
{ 	
if 
( 
cliente 
== 
null 
)  
throw 
new !
ArgumentNullException /
(/ 0
nameof0 6
(6 7
cliente7 >
)> ?
,? @
$strA _
)_ `
;` a
await 
_context 
. 
Clientes #
.# $
Where$ )
() *
c* +
=>, .
c/ 0
.0 1
Id1 3
==4 6
cliente7 >
.> ?
Id? A
)A B
.B C
ExecuteDeleteAsyncC U
(U V
)V W
;W X
await 
_context 
. 
SaveChangesAsync +
(+ ,
), -
;- .
} 	
public 
async 
Task 
< 
Cliente !
>! "
Get# &
(& '
int' *
id+ -
)- .
{   	
var!! 
cliente!! 
=!! 
await!! 
_context!!  (
.!!( )
Clientes!!) 1
.!!1 2
	FindAsync!!2 ;
(!!; <
id!!< >
)!!> ?
;!!? @
if"" 
("" 
cliente"" 
=="" 
null"" 
)""  
{## 
throw$$ 
new$$  
KeyNotFoundException$$ .
($$. /
$"$$/ 1
$str$$1 @
{$$@ A
id$$A C
}$$C D
$str$$D X
"$$X Y
)$$Y Z
;$$Z [
}%% 
return&& 
cliente&& 
;&& 
}'' 	
public)) 
async)) 
Task)) 
<)) 
List)) 
<)) 
Cliente)) &
>))& '
>))' (
GetAll))) /
())/ 0
int))0 3
numero_pagina))4 A
,))A B
int))C F
quantidade_p_pagina))G Z
)))Z [
{** 	
var++ 
listaClientes++ 
=++ 
await++  %
_context++& .
.++. /
Clientes++/ 7
.++7 8
Skip++8 <
(++< =
numero_pagina++= J
*++K L
quantidade_p_pagina++M `
)++` a
.++a b
Take++b f
(++f g
quantidade_p_pagina++g z
)++z {
.++{ |
ToListAsync	++| á
(
++á à
)
++à â
;
++â ä
return,, 
listaClientes,,  
;,,  !
}-- 	
public// 
async// 
Task// 
Update//  
(//  !
Cliente//! (
cliente//) 0
)//0 1
{00 	
_context11 
.11 
ChangeTracker11 "
.11" #
Clear11# (
(11( )
)11) *
;11* +
_context22 
.22 
Clientes22 
.22 
Update22 $
(22$ %
cliente22% ,
)22, -
;22- .
await33 
_context33 
.33 
SaveChangesAsync33 +
(33+ ,
)33, -
;33- .
}44 	
}55 
}66 ¨s
nC:\Users\ifspn\OneDrive\Desktop\APPS\backend-portal-sv\backend-portal-sv\Infra\Repository\ChatbotRepository.cs
	namespace 	
Infra
 
. 

Repository 
{ 
public 

class 
ChatbotRepository "
:# $
IChatbotRepository% 7
{ 
public 
readonly 
IStorageHandler '
_storageHandler( 7
;7 8
public 
readonly 
ConnectionContext )
_context* 2
;2 3
public 
readonly 

HttpClient "
_httpClient# .
;. /
public 
readonly 
string 
_apiUrl &
;& '
public 
readonly 
string 
_apiKey &
;& '
public 
readonly 
string 

_modelName )
;) *
public 
readonly 
float 
_temperature *
;* +
public 
readonly 
int 

_maxTokens &
;& '
public 
readonly 
float 
_topP #
;# $
public 
static 
float 

ParseFloat &
(& '
string' -
value. 3
)3 4
=>5 7
float8 =
.= >
Parse> C
(C D
valueD I
.I J
ReplaceJ Q
(Q R
$strR U
,U V
$strW Z
)Z [
)[ \
;\ ]
public 
ChatbotRepository  
(  !
IConfiguration! /
configuration0 =
,= >
ConnectionContext? P
contextQ X
,X Y
IStorageHandlerZ i
storageHandlerj x
)x y
{ 	
_storageHandler 
= 
storageHandler ,
;, -
_context 
= 
context 
; 
_apiUrl!! 
=!! 
configuration!! #
[!!# $
$str!!$ 5
]!!5 6
??!!7 9
$str!!: <
;!!< =
_apiKey"" 
="" 
configuration"" #
[""# $
$str""$ 8
]""8 9
??"": <
$str""= ?
;""? @

_modelName## 
=## 
configuration## &
[##& '
$str##' >
]##> ?
??##@ B
$str##C E
;##E F
_temperature$$ 
=$$ 

ParseFloat$$ %
($$% &
configuration$$& 3
[$$3 4
$str$$4 M
]$$M N
??$$O Q
throw$$R W
new$$X [!
ArgumentNullException$$\ q
($$q r
$str	$$r ã
)
$$ã å
)
$$å ç
;
$$ç é

_maxTokens%% 
=%% 
int%% 
.%% 
Parse%% "
(%%" #
configuration%%# 0
[%%0 1
$str%%1 H
]%%H I
??%%J L
throw%%M R
new%%S V!
ArgumentNullException%%W l
(%%l m
$str	%%m Ñ
)
%%Ñ Ö
)
%%Ö Ü
;
%%Ü á
_topP&& 
=&& 

ParseFloat&& 
(&& 
configuration&& ,
[&&, -
$str&&- ?
]&&? @
??&&A C
throw&&D I
new&&J M!
ArgumentNullException&&N c
(&&c d
$str&&d v
)&&v w
)&&w x
;&&x y
_httpClient'' 
='' 
new'' 

HttpClient'' (
(''( )
)'') *
;''* +
ConfigureHttpClient(( 
(((  
)((  !
;((! "
})) 	
public-- 
void-- 
ConfigureHttpClient-- '
(--' (
)--( )
{.. 	
_httpClient// 
.// !
DefaultRequestHeaders// -
.//- .
Authorization//. ;
=//< =
new//> A%
AuthenticationHeaderValue//B [
(//[ \
$str//\ d
,//d e
_apiKey//f m
)//m n
;//n o
_httpClient00 
.00 !
DefaultRequestHeaders00 -
.00- .
Add00. 1
(001 2
$str002 D
,00D E
$str00F L
)00L M
;00M N
}11 	
public33 
async33 
Task33 
<33 
string33  
>33  !
SendMessageAsync33" 2
(332 3
string333 9
userMessage33: E
)33E F
{44 	
var55 
prompt55 
=55 
await55 
CreateChatPrompt55 /
(55/ 0
userMessage550 ;
,55; <
await55= B
_storageHandler55C R
.55R S+
GetPrecosParaTodosDestinosAsync55S r
(55r s
)55s t
)55t u
;55u v
var66 
payload66 
=66  
CreateRequestPayload66 .
(66. /
prompt66/ 5
)665 6
;666 7
var77 
response77 
=77 
await77  
_httpClient77! ,
.77, -
	PostAsync77- 6
(776 7
_apiUrl777 >
,77> ?
SerializePayload77@ P
(77P Q
payload77Q X
)77X Y
)77Y Z
;77Z [
return99 
await99 
HandleResponseAsync99 ,
(99, -
response99- 5
)995 6
;996 7
}:: 	
public<< 
async<< 
Task<< 
<<< 
string<<  
><<  !
CreateChatPrompt<<" 2
(<<2 3
string<<3 9
userMessage<<: E
,<<E F
string<<G M
destinationPrices<<N _
)<<_ `
{== 	
return>> 
$@">> 
$str>? 
{?? 
await?? 
_storageHandler?? &
.??& '+
GetPrecosParaTodosDestinosAsync??' F
(??F G
)??G H
}??H I
$str	??I ∑
{
??∑ ∏
userMessage
??∏ √
}
??√ ƒ
$str
??ƒ ˇ
"
??ˇ Ä
;
??Ä Å
}@@ 	
publicAA 
objectAA  
CreateRequestPayloadAA *
(AA* +
stringAA+ 1
promptAA2 8
)AA8 9
{BB 	
returnCC 
newCC 
{DD 
modelEE 
=EE 

_modelNameEE "
,EE" #
messagesFF 
=FF 
newFF 
[FF 
]FF  
{FF! "
newFF# &
{FF' (
roleFF) -
=FF. /
$strFF0 6
,FF6 7
contentFF8 ?
=FF@ A
promptFFB H
}FFI J
}FFK L
,FFL M
temperatureGG 
=GG 
_temperatureGG *
,GG* +

max_tokensHH 
=HH 

_maxTokensHH '
,HH' (
top_pII 
=II 
_topPII 
}JJ 
;JJ 
}KK 	
publicMM 
staticMM 
StringContentMM #
SerializePayloadMM$ 4
(MM4 5
objectMM5 ;
payloadMM< C
)MMC D
{NN 	
returnOO 
newOO 
StringContentOO $
(OO$ %
JsonConvertOO% 0
.OO0 1
SerializeObjectOO1 @
(OO@ A
payloadOOA H
)OOH I
,OOI J
EncodingOOK S
.OOS T
UTF8OOT X
,OOX Y
$strOOZ l
)OOl m
;OOm n
}PP 	
publicRR 
asyncRR 
TaskRR 
<RR 
stringRR  
>RR  !
HandleResponseAsyncRR" 5
(RR5 6
HttpResponseMessageRR6 I
responseRRJ R
)RRR S
{SS 	
ifTT 
(TT 
responseTT 
.TT 
IsSuccessStatusCodeTT ,
)TT, -
{UU 
varVV 
contentVV 
=VV 
awaitVV #
responseVV$ ,
.VV, -
ContentVV- 4
.VV4 5
ReadAsStringAsyncVV5 F
(VVF G
)VVG H
;VVH I
varWW 
resultWW 
=WW 
JsonConvertWW (
.WW( )
DeserializeObjectWW) :
<WW: ;
DomainWW; A
.WWA B
EntityWWB H
.WWH I
ResponseWWI Q
>WWQ R
(WWR S
contentWWS Z
)WWZ [
;WW[ \
returnXX 
resultXX 
?XX 
.XX 
choicesXX &
.XX& '
FirstOrDefaultXX' 5
(XX5 6
)XX6 7
?XX7 8
.XX8 9
messageXX9 @
?XX@ A
.XXA B
contentXXB I
??XXJ L
stringXXM S
.XXS T
EmptyXXT Y
;XXY Z
}YY 
var[[ 
errorDetails[[ 
=[[ 
await[[ $
response[[% -
.[[- .
Content[[. 5
.[[5 6
ReadAsStringAsync[[6 G
([[G H
)[[H I
;[[I J
throw\\ 
new\\ !
HttpResponseException\\ +
(\\+ ,
response\\, 4
.\\4 5

StatusCode\\5 ?
,\\? @
$"\\A C
$str\\C U
{\\U V
response\\V ^
.\\^ _

StatusCode\\_ i
}\\i j
$str\\j m
{\\m n
errorDetails\\n z
}\\z {
"\\{ |
)\\| }
;\\} ~
}]] 	
public__ 
async__ 
Task__ 
CriaHistorico__ '
(__' (
Chat__( ,
chat__- 1
)__1 2
{`` 	
awaitaa 
_contextaa 
.aa 
Chataa 
.aa  
AddAsyncaa  (
(aa( )
chataa) -
)aa- .
;aa. /
awaitbb 
_contextbb 
.bb 
SaveChangesAsyncbb +
(bb+ ,
)bb, -
;bb- .
}cc 	
publicee 
asyncee 
Taskee 
AtualizaHistoricoee +
(ee+ ,
Chatee, 0
chatee1 5
)ee5 6
{ff 	
vargg 
chatIdgg 
=gg 
chatgg 
.gg 
Idgg  
;gg  !
varhh 

satisfacaohh 
=hh 
chathh !
.hh! "

Satisfacaohh" ,
;hh, -
awaitjj 
_contextjj 
.jj 
Chatjj 
.jj  
Wherejj  %
(jj% &
cjj& '
=>jj( *
cjj+ ,
.jj, -
Idjj- /
==jj0 2
chatIdjj3 9
)jj9 :
.jj: ;
ExecuteUpdateAsyncjj; M
(jjM N
sjjN O
=>jjP R
sjjS T
.jjT U
SetPropertyjjU `
(jj` a
bjja b
=>jjc e
bjjf g
.jjg h

Satisfacaojjh r
,jjr s

satisfacaojjt ~
)jj~ 
)	jj Ä
;
jjÄ Å
awaitkk 
_contextkk 
.kk 
SaveChangesAsynckk +
(kk+ ,
)kk, -
;kk- .
}ll 	
publicnn 
asyncnn 
Tasknn 
<nn 
Listnn 
<nn 
Chatnn #
>nn# $
>nn$ %
PegaHistoricosnn& 4
(nn4 5
)nn5 6
{oo 	
returnpp 
awaitpp 
_contextpp !
.pp! "
Chatpp" &
.pp& '
ToListAsyncpp' 2
(pp2 3
)pp3 4
;pp4 5
}qq 	
publicss 
asyncss 
Taskss 
<ss 
intss 
>ss !
validaCategoriaComLLMss 4
(ss4 5
stringss5 ;
resumoConversass< J
)ssJ K
{tt 	
varuu 
promptuu 
=uu  
CreateCategoryPromptuu .
(uu. /
resumoConversauu/ =
)uu= >
;uu> ?
varvv 
payloadvv 
=vv  
CreateRequestPayloadvv .
(vv. /
promptvv/ 5
)vv5 6
;vv6 7
varxx 
payloadJsonxx 
=xx 
JsonConvertxx )
.xx) *
SerializeObjectxx* 9
(xx9 :
payloadxx: A
,xxA B
newxxC F"
JsonSerializerSettingsxxG ]
{yy !
ReferenceLoopHandlingzz %
=zz& '!
ReferenceLoopHandlingzz( =
.zz= >
Ignorezz> D
}{{ 
){{ 
;{{ 
var}} 
response}} 
=}} 
await}}  
_httpClient}}! ,
.}}, -
	PostAsync}}- 6
(}}6 7
_apiUrl}}7 >
,}}> ?
new}}@ C
StringContent}}D Q
(}}Q R
payloadJson}}R ]
,}}] ^
Encoding}}_ g
.}}g h
UTF8}}h l
,}}l m
$str	}}n Ä
)
}}Ä Å
)
}}Å Ç
;
}}Ç É
var~~ 
result~~ 
=~~ 
await~~ 
HandleResponseAsync~~ 2
(~~2 3
response~~3 ;
)~~; <
;~~< =
return
ÄÄ 
int
ÄÄ 
.
ÄÄ 
TryParse
ÄÄ 
(
ÄÄ  
result
ÄÄ  &
,
ÄÄ& '
out
ÄÄ( +
var
ÄÄ, /
category
ÄÄ0 8
)
ÄÄ8 9
?
ÄÄ: ;
category
ÄÄ< D
:
ÄÄE F
$num
ÄÄG I
;
ÄÄI J
}
ÅÅ 	
public
ÑÑ 
static
ÑÑ 
string
ÑÑ "
CreateCategoryPrompt
ÑÑ 1
(
ÑÑ1 2
string
ÑÑ2 8
contexto
ÑÑ9 A
)
ÑÑA B
{
ÖÖ 	
return
ÜÜ 
@$"
ÜÜ 
$strÜÜ √
{ÜÜ√ ƒ
contextoÜÜƒ Ã
.ÜÜÃ Õ
ReplaceÜÜÕ ‘
(ÜÜ‘ ’
$strÜÜ’ ÿ
,ÜÜÿ Ÿ
$strÜÜ⁄ ‹
)ÜÜ‹ ›
.ÜÜ› ﬁ
ReplaceÜÜﬁ Â
(ÜÜÂ Ê
$strÜÜÊ È
,ÜÜÈ Í
$strÜÜÎ Ì
)ÜÜÌ Ó
.ÜÜÓ Ô
ReplaceÜÜÔ ˆ
(ÜÜˆ ˜
$strÜÜ˜ ˙
,ÜÜ˙ ˚
$strÜÜ¸ ˛
)ÜÜ˛ ˇ
.ÜÜˇ Ä
ReplaceÜÜÄ á
(ÜÜá à
$strÜÜà ã
,ÜÜã å
$strÜÜç è
)ÜÜè ê
}ÜÜê ë
$strÜÜë ®
"ÜÜ® ©
.ÜÜ© ™
ReplaceÜÜ™ ±
(ÜÜ± ≤
$strÜÜ≤ ∂
,ÜÜ∂ ∑
$strÜÜ∏ ∫
)ÜÜ∫ ª
.ÜÜª º
ReplaceÜÜº √
(ÜÜ√ ƒ
$strÜÜƒ »
,ÜÜ» …
$strÜÜ  Ã
)ÜÜÃ Õ
;ÜÜÕ Œ
}
áá 	
}
àà 
}ââ Ã
mC:\Users\ifspn\OneDrive\Desktop\APPS\backend-portal-sv\backend-portal-sv\Infra\Conection\ConnectionContext.cs
	namespace 	
Infra
 
. 
	Conection 
{ 
public 

class 
ConnectionContext "
:# $
	DbContext% .
{		 
private

 
readonly

 
IConfiguration

 '
_configuration

( 6
;

6 7
public 
DbSet 
< 
Cliente 
> 
Clientes &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
DbSet 
< 
Chat 
> 
Chat 
{  !
get" %
;% &
set' *
;* +
}, -
public 
ConnectionContext  
(  !
IConfiguration! /
configuration0 =
)= >
{ 	
_configuration 
= 
configuration *
;* +
} 	
	protected 
override 
void 
OnConfiguring  -
(- .#
DbContextOptionsBuilder. E
optionsBuilderF T
)T U
{ 	
if 
( 
! 
optionsBuilder 
.  
IsConfigured  ,
), -
{ 
string 

strConexao !
=" #
_configuration$ 2
.2 3
GetConnectionString3 F
(F G
$strG Z
)Z [
??\ ^
$str_ a
;a b
optionsBuilder 
. 
UseSqlServer +
(+ ,

strConexao, 6
)6 7
;7 8
} 
} 	
} 
} 