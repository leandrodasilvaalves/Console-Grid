# Console Grid

O objetivo deste projeto é simular uma grid de visualização simples utilizando aplicativo console.

## Tecnologia Utilizadas

 - .Net 6
 - Linq



## Como instalar:
```sh
> dotnet add package LeandroAlves.ConsoleGrid  
```  

## Exemplo:

```c#
    var produtos = new List<Produto>();
    produtos.Add(new Produto(1, "Arroz", 20.35m, DateTime.Now));
    produtos.Add(new Produto(2, "Feijao", 12.0m, DateTime.Now));
    produtos.Add(new Produto(3, "Oleo", 14.16m, DateTime.Now));
    produtos.Add(new Produto(4, "Ovo 30un", 18.0m, DateTime.Now));

    var grid = new Grid("lista de produtos", 4, 20, 10, 11);            

    grid.ColumnsName("Id", "Descricao", "Valor", "Data");
    grid.ColumnsFormat(string.Empty, string.Empty, "{0:c2}", "{0:dd/MM/yyyy}");
    grid.ColumnsAlign(Align.RIGHT, Align.LEFT, Align.RIGHT, Align.RIGHT);
    grid.DataSource(produtos);
    grid.Footer("Total: " + produtos.Sum(p => p.Valor).ToString("c2"));
    grid.Print();
```

```
 -----------------------------------------------------------
 | LISTA DE PRODUTOS                                       | 
 -----------------------------------------------------------
 | Id   | Descricao            | Valor      | Data         | 
 -----------------------------------------------------------
 |    1 | Arroz                |   R$ 20,35 |   08/06/2022 | 
 -----------------------------------------------------------
 |    2 | Feijao               |   R$ 12,00 |   08/06/2022 | 
 -----------------------------------------------------------
 |    3 | Oleo                 |   R$ 14,16 |   08/06/2022 | 
 -----------------------------------------------------------
 |    4 | Ovo 30un             |   R$ 18,00 |   08/06/2022 | 
 -----------------------------------------------------------
 |                                         Total: R$ 64,51 | 
 ----------------------------------------------------------- 
```

### Exemplo de rodapé utilizando colunas
```c#
    var col1 = "Qtde: " + produtos.Count;
    var col2 = "Total: " + produtos.Sum(p => p.Valor).ToString("c2");
    var col3 = "Média: " + produtos.Average(p => p.Valor).ToString("c2");

    grid.Footer(col1, col2, col3);
    grid.Print();
```
```sh
 -----------------------------------------------------------
 | LISTA DE PRODUTOS                                       | 
 -----------------------------------------------------------
 | Id   | Descricao            | Valor      | Data         | 
 -----------------------------------------------------------
 | 1    | Arroz                | R$ 20,35   | 05/06/2022   | 
 -----------------------------------------------------------
 | 2    | Feijao               | R$ 12,00   | 05/06/2022   | 
 -----------------------------------------------------------
 | 3    | Oleo                 | R$ 14,16   | 05/06/2022   | 
 -----------------------------------------------------------
 | 4    | Ovo 30un             | R$ 18,00   | 05/06/2022   | 
 -----------------------------------------------------------
 | Qtde: 4          | Total: R$ 64,51  | Média: R$ 16,13   | 
 -----------------------------------------------------------
```

### Exemplo de rodapé com colunas e alinhamento
```c#
    var col1 = "Qtde: " + produtos.Count;
    var col2 = "Total: " + produtos.Sum(p => p.Valor).ToString("c2");

    grid.FooterAlign(Align.LEFT, Align.RIGHT);
    grid.Footer(col1, col2);
    grid.Print();
```

```sh
 -----------------------------------------------------------
 | LISTA DE PRODUTOS                                       | 
 -----------------------------------------------------------
 | Id   | Descricao            | Valor      | Data         | 
 -----------------------------------------------------------
 |    1 | Arroz                |   R$ 20,35 |   08/06/2022 | 
 -----------------------------------------------------------
 |    2 | Feijao               |   R$ 12,00 |   08/06/2022 | 
 -----------------------------------------------------------
 |    3 | Oleo                 |   R$ 14,16 |   08/06/2022 | 
 -----------------------------------------------------------
 |    4 | Ovo 30un             |   R$ 18,00 |   08/06/2022 | 
 -----------------------------------------------------------
 | Qtde: 4                    |            Total: R$ 64,51 | 
 -----------------------------------------------------------
```

## Autores
 [<img src="https://avatars.githubusercontent.com/u/24819158?v=4" width=115><br><sub>Leandro Alves</sub>](https://github.com/leandrodasilvaalves)
