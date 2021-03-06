﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SintegraBr.Classes;
using SintegraBr.Common;

namespace SintegraBr.Tests
{
    [TestClass]
    public class GeracaoUnitTests
    {
        [TestMethod]
        public void GerarRegistro10()
        {
            var r10 = new Registro10(
                Cnpj: "01234567000899",
                Ie: "1012345678",
                RazaoSocial: "EMPRESA DE TESTE",
                Municipio: "CIDADE DE DEUS",
                Uf: "GO",
                Fax: "123456789",
                DataInicial: DateTime.Now.ObterPrimeiroDiaMesAtual(),
                DataFinal: DateTime.Now.ObterUltimoDiaMesAtual(),
                CodFin: CodFinalidadeArquivo.Cod1
                );

            var result = r10.EscreverCampos();

            var actual = new List<string>();
            actual.Add(result.ToStringSafe());

            var expected = new List<string>();
            expected.Add("10012345670008991012345678    EMPRESA DE TESTE                   CIDADE DE DEUS                GO01234567892017030120170331331");

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GerarRegistro11()
        {
            var r11 = new Registro11(
                Logradouro: "RUA SEM NOME PARA TESTE",
                Numero: "",
                Complemento: "",
                Bairro: "CENTRO",
                Cep: "36900000",
                NomeContato: "ADEMERIO EDUARDO MOREIRA",
                NumeroContato: "3333315808"
                );

            var result = r11.EscreverCampos();

            var actual = new List<string>();
            actual.Add(result.ToStringSafe());

            var expected = new List<string>();
            expected.Add("11RUA SEM NOME PARA TESTE           00000s/nº                  CENTRO         36900000ADEMERIO EDUARDO MOREIRA    003333315808");

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GerarRegistro90()
        {
            var linhas = new List<string>();

            var r10 = new Registro10(
                Cnpj: "01234567000899",
                Ie: "1012345678",
                RazaoSocial: "EMPRESA DE TESTE",
                Municipio: "CIDADE DE DEUS",
                Uf: "GO",
                Fax: "123456789",
                DataInicial: DateTime.Now.ObterPrimeiroDiaMesAtual(),
                DataFinal: DateTime.Now.ObterUltimoDiaMesAtual(),
                CodFin: CodFinalidadeArquivo.Cod1
                );

            var resultR10 = r10.EscreverCampos();

            var r11 = new Registro11(
                Logradouro: "RUA SEM NOME PARA TESTE",
                Numero: "",
                Complemento: "",
                Bairro: "CENTRO",
                Cep: "36900000",
                NomeContato: "ADEMERIO EDUARDO MOREIRA",
                NumeroContato: "3333315808"
                );

            var resultR11 = r11.EscreverCampos();

            var r50 = new Registro50();

            // Exemplo de nota de compra de material p/ uso ou consumo (copos descartáveis por exemplo)
            r50.Cnpj = "01234567000899";
            r50.InscrEstadual = "1012345678";
            r50.DataEmissaoRecebimento = DateTime.Now;
            r50.Uf = "GO";
            r50.Modelo = 55;
            r50.Serie = "001";
            r50.Numero = 123456;
            r50.Cfop = 1556;
            r50.Emitente = "T";
            r50.ValorTotal = 50.55M;
            r50.ValorOutras = 50.55M;
            r50.SituacaoNotaFiscal = "N";

            var resultR50 = r50.EscreverCampos();

            var r51 = new Registro51();

            r51.Cnpj = "01234567000899";
            r51.InscrEstadual = "1012345678";

            var resultR51 = r51.EscreverCampos();

            var r53 = new Registro53();

            r53.Cnpj = "01234567000899";
            r53.InscrEstadual = "1012345678";

            var resultR53 = r53.EscreverCampos();

            var r54 = new Registro54();

            r54.Cnpj = "01234567000899";

            var resultR54 = r54.EscreverCampos();

            var r60M = new Registro60M();

            r60M.DataEmissao = DateTime.Now;

            var resultR60M = r60M.EscreverCampos();

            var r61 = new Registro61();

            r61.DataEmissao = DateTime.Now;

            var resultR61 = r61.EscreverCampos();

            var r61R = new Registro61R();

            r61R.DataEmissao = DateTime.Now;

            var resultR61R = r61R.EscreverCampos();

            var r70 = new Registro70();

            r70.Cnpj = "01234567000899";
            r70.InscrEstadual = "1012345678";

            var resultR70 = r70.EscreverCampos();

            var r74 = new Registro74();

            r74.DataInventario = DateTime.Now;

            var resultR74 = r74.EscreverCampos();

            var r75 = new Registro75();

            r75.DataInicial = DateTime.Now.ObterPrimeiroDiaMesAtual();
            r75.DataFinal = DateTime.Now.ObterUltimoDiaMesAtual();

            var resultR75 = r75.EscreverCampos();

            linhas.Add(resultR10);
            linhas.Add(resultR11);
            linhas.Add(resultR50);
            linhas.Add(resultR51);
            linhas.Add(resultR53);
            linhas.Add(resultR54);
            linhas.Add(resultR60M);
            linhas.Add(resultR61);
            linhas.Add(resultR61R);
            linhas.Add(resultR70);
            linhas.Add(resultR74);
            linhas.Add(resultR75);

            var r90 = new Registro90("01234567000899", "1012345678", linhas).EscreverRegistro90();

            var actual = new List<string>();
            linhas.ForEach(linha => actual.Add(linha.ToStringSafe()));
            
            var expected = new List<string>();
            expected.Add("10012345670008991012345678    EMPRESA DE TESTE                   CIDADE DE DEUS                GO01234567892017030120170331331");
            expected.Add("11RUA SEM NOME PARA TESTE           00000s/nº                  CENTRO         36900000ADEMERIO EDUARDO MOREIRA    003333315808");
            expected.Add("50012345670008991012345678    20170312GO550011234561556T00000000050550000000005055N");
            expected.Add("51012345670008991012345678    00010101     00000000000000000000000000000000000000000000000000000000000000                     ");
            expected.Add("53012345670008991012345678    00010101  00   0000000000                                ");
            expected.Add("540123456700089900   0000000000   000              00000000000000000000000");
            expected.Add("60M20170312                    000  00000000000000000000000000000000000000000000000000000                                     ");
            expected.Add("61                            20170312     0000000000000000000000000 ");
            expected.Add("61R032017              00000000000000000000000000000                                                      ");
            expected.Add("70012345670008991012345678    00010101  00   000000000000000000000000 ");
            expected.Add("7420170312              00000000000000000000000000                                                              ");
            expected.Add("752017030120170331                                                                                 ");

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
