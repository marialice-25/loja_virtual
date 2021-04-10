﻿using Loja_Virtual_Dev.DAL;
using Loja_Virtual_Dev.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Loja_Virtual_Dev.BLL
{
    public class fornecedorBLL
    {
        private MySqlDAL con = new MySqlDAL();

        public void Inserir(fornecedor fornecedor)
        {
            string sql = string.Format($@"INSERT INTO FORNECEDOR VALUES(NULL, '{fornecedor.Id}','{fornecedor.Nome}','{fornecedor.Cnpj}',
                                       '{fornecedor.Email}','{fornecedor.Telefone}','{fornecedor.NomeRepresentante}','{fornecedor.TelefoneRepresentante}',
                                       '{fornecedor.Produtosid}';");
            con.ExecutarSQL(sql);
        }

        public void Excluir(fornecedor fornecedor)
        {
            string sql = string.Format($@"DELETE FROM FORNECEDOR WHERE ID = {fornecedor.Id};");
            con.ExecutarSQL(sql);
        }

        public void Alterar(fornecedor fornecedor)
        {
            string sql = string.Format($@"UPDATE FORNECEDOR  SET NOME = '{fornecedor.Id}',NOME='{fornecedor.Nome}',CNPJ='{fornecedor.Cnpj}',
                                      EMAIL= '{fornecedor.Email}',TELEFONE='{fornecedor.Telefone}',NOME_REPRESENTANTE='{fornecedor.NomeRepresentante}',
                                      TELEFONE_REPRESENTANTE='{fornecedor.TelefoneRepresentante}';");
            con.ExecutarSQL(sql);
        }

        public DataTable ConsultarID(int id)
        {
            string sql = string.Format($@"SELECT * FROM FORNECEDOR WHERE ID = '{id}';");
            return con.ExecutarConsulta(sql);
        }
        public DataTable Pesquisar(string condicao)
        {
            string sql = string.Format($@"SELECT A.ID, A.NOME, A.DESCRICAO, A.VALOR,A.VALIDADE, B.NOME, B.DESCRICAO, C.NOME, C.NOME_REPRESENTANTE 
                                       FROM PRODUTOS AS A, CATEGORIA AS B, FORNECEDOR AS C WHERE A.CATEGORIAID = B.ID AND A.FORNECEDORID = C.ID
                                       AND {condicao} ORDER BY A.ID;");
            return con.ExecutarConsulta(sql);
        }
    }
}