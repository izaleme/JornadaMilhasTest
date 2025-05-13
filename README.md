# Jornada Milhas Test

<h4 align="center"> 
    :construction:  Projeto em construção  :construction:
</h4>

### Testes Automatizados com .NET
<p>Este repositório apresenta um projeto de <b>testes automatizados</b> utilizando a plataforma .NET. Para a implementação dos testes, foi selecionada a biblioteca xUnit, uma das mais robustas e populares para o ecossistema .NET.</p>
<p>O foco deste projeto é a aplicação "Jornada Milhas", uma plataforma de ofertas de viagens.</p>
<p>Aqui, você encontrará a estrutura de testes, exemplos práticos e a configuração necessária para executar e validar os testes automatizados da aplicação.</p>

##
### Features
- [x] Criar testes automatizados utilizando a biblioteca XUnit
- [x] Escrever testes de unidade para garantir a qualidade do código
- [x] Aplicar o padrão AAA para escrever testes com mais clareza e organização
- [x] Reestruturar os testes seguindo um padrão convencional de nomenclatura
- [x] Testar conjuntos de dados diferentes num mesmo teste, utilizando o Theory
- [x] Correção de problemas com testes de mutação e utilizando o Theory

##
### Instalações
<p>Necessário instalar a biblioteca Stricker dotnet para realizar os testes de mutação.</p>
<li>Botão direito no projeto JornadaMilhas.Test --> Abrir no terminal --> colar o comando <i>dotnet tool install -g dotnet-stryker</i></li>
<li>Para roda o stryker dentro do projeto --> <i>dotnet Stryker</i></li>
<br>

##
### Observações:

#### Padronização de testes
<p>Existe um padrão de teste denominado padrão <b>AAA (triplo A)</b>, que consiste em:
<ul>
<li>Arrange (Cenário)</li>
<li>Act (Ação)</li>
<li>Assert (Validação)</li>
</ul>
<p>O objetivo do <b>Assert</b> é garantir que o comportamento do código testado esteja alinhado aos resultados esperados, fornecendo feedback imediato.</p>
<p>Há também o padrão <b>Given-When-Then pattern</b>, que é semelhante, mas é mais orientado para o comportamento do que à estrutura, como o padrão AAA.</p>
<br>

#### Padronização de nomenclatura
<p>Um bom padrão de nomenclatura utiliza o nome do método que está sendo testado, o cenário e o comportamento esperado.</p>
<p>A especificação detalhada que descreve as condições, entradas, procedimentos e resultados esperados para verificar se um determinado componente do sistema está funcionando corretamente é chamada de caso de teste.</p>
<br>

#### Notações do xUnit
<p>O xUnity Theory ajuda a testar vários cenários diferentes no mesmo cenário de teste. Ele auxilia em ter um código de testes mais limpo, legível e com qualidade.</p>

<ul>Além de Fact e Theory, existem outras notações do xUnit que podem ser utilizadas:
<li>[TestFixture] - uma classe que contém um conjunto de testes de unidade relacionados</li>
<li>[Test] - utilizada para identificar testes distintos dentro de uma mesma classe de teste</li>
<li>[Ignore] - utilizada para ignorar um teste específico durante a execução</li>
<li>[Collection] - utilizada para agrupar testes em coleções específicas</li>
</ul><br>

### Testes de Mutação
<p>Testes de mutação são uma técnica avançada de testes de software que visam avaliar a eficácia dos testes de unidade identificando lacunas na cobertura do código. São muito úteis para detectar mudanças semânticas significativas no código que possam introduzir bugs. Em etapas:</p>
<li><b>Aplicar mutações:</b> Modificações automáticas simulam pequenos erros no código.</li>
<li><b>Rodar os testes:</b> Verifica se os testes identificam as mudanças (mutantes "mortos").</li>
<li><b>Avaliar cobertura:</b> Muitos mutantes não detectados indicam testes insuficientes.</li>
<li><b>Melhorar os testes:</b> Ajusta-se ou adicionam-se testes para aumentar a eficácia.</li>
