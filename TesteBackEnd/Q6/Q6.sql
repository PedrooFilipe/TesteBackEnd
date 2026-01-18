 SELECT   
 pl.nome AS produto_limpeza,
 al.nome AS alimento,
 (eepl.preco + ee.preco) * 0.85 AS preco_kit,
 ((eepl.preco + ee.preco) * 0.85) - (eepl.custo - ee.custo) as lucro_kit 
 FROM produto_limpeza pl 
 JOIN pesquisa_mercado pm    
 ON pm.id_produto_limpeza = pl.id 
 JOIN elemento_estoque eepl    
 ON eepl.id = pl.id_elemento_estoque 
 JOIN alimento al    
 ON al.data_validade < CURRENT_DATE + INTERVAL '5 day' 
 JOIN elemento_estoque ee   
 ON ee.id = al.id_elemento_estoque 
 GROUP BY   pl.id, pl.nome,
    al.id, al.nome, eepl.custo, ee.custo,
    eepl.preco, ee.preco 
HAVING AVG(pm.satisfacao) > 70 
ORDER BY lucro_kit DESC