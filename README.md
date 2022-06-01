# Console Grid

O objetivo deste projeto é simular uma grid de visualização simples utilizando aplicativo console.

## Tecnologia Utilizadas

 - .Net 6
 - Linq


## Exemplo:

```c#
    var produtos = new List<Produto>();
    produtos.Add(new Produto(1, "Arroz", 20.35m, DateTime.Now));
    produtos.Add(new Produto(2, "Feijao", 12.0m, DateTime.Now));
    produtos.Add(new Produto(3, "Oleo", 14.16m, DateTime.Now));
    produtos.Add(new Produto(4, "Ovo 30un", 18.0m, DateTime.Now));

    var grid = new Grid("lista de produtos", 4, 20, 10, 11);            

    grid.ColumnsTitle("Id", "Descricao", "Valor", "Data");
    grid.ColumnsFormat(string.Empty, string.Empty, "{0:c2}", "{0:dd/MM/yyyy}");
    grid.DataSource(produtos);
    grid.Footer("Total: " + produtos.Sum(p => p.Valor).ToString("c2"));
    grid.Print();
```
------------------------------------------------------
| LISTA DE PRODUTOS                                  |
------------------------------------------------------
| Id  | Descricao           | Valor     | Data       | 
------------------------------------------------------
| 1   | Arroz               | R$ 20,35  | 29/05/2022 | 
------------------------------------------------------
| 2   | Feijao              | R$ 12,00  | 29/05/2022 | 
------------------------------------------------------
| 3   | Oleo                | R$ 14,16  | 29/05/2022 | 
------------------------------------------------------
| 4   | Ovo 30un            | R$ 18,00  | 29/05/2022 | 
------------------------------------------------------
|                                    Total: R$ 64,51 |
------------------------------------------------------  

## Como instalar:
```sh
> dotnet add package LeandroAlves.ConsoleGrid  
```  

## Autores
 [<img src="https://avatars.githubusercontent.com/u/24819158?v=4" width=115><br><sub>Leandro Alves</sub>](https://github.com/leandrodasilvaalves)