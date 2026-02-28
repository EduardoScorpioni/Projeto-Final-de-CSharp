-- phpMyAdmin SQL Dump
-- version 4.1.4
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 28-Fev-2026 às 17:15
-- Versão do servidor: 5.6.15-log
-- PHP Version: 5.5.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `escola`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `alunos`
--

CREATE TABLE IF NOT EXISTS `alunos` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(200) NOT NULL,
  `email` varchar(200) NOT NULL,
  `rm` int(11) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Extraindo dados da tabela `alunos`
--

INSERT INTO `alunos` (`codigo`, `nome`, `email`, `rm`) VALUES
(4, 'lua', 'lua@gmail.com', 15974);

-- --------------------------------------------------------

--
-- Estrutura da tabela `carros`
--

CREATE TABLE IF NOT EXISTS `carros` (
  `carro_id` int(11) NOT NULL AUTO_INCREMENT,
  `modelo` varchar(50) NOT NULL,
  `marca` varchar(50) NOT NULL,
  `ano` int(11) NOT NULL,
  `placa` varchar(10) NOT NULL,
  `cor` varchar(20) NOT NULL,
  `status` varchar(20) NOT NULL,
  `preco_diaria` decimal(10,2) NOT NULL,
  `categoria` varchar(30) NOT NULL,
  PRIMARY KEY (`carro_id`),
  UNIQUE KEY `placa` (`placa`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Extraindo dados da tabela `carros`
--

INSERT INTO `carros` (`carro_id`, `modelo`, `marca`, `ano`, `placa`, `cor`, `status`, `preco_diaria`, `categoria`) VALUES
(1, 'Corolla', 'Toyota', 2021, 'ABC1234', 'Preto', 'Disponível', '150.00', 'Sedan'),
(2, 'Civic', 'Honda', 2020, 'DEF5678', 'Branco', 'Disponível', '160.00', 'Sedan'),
(3, 'Ecosport', 'Ford', 2019, 'GHI9012', 'Prata', 'Alugado', '140.00', 'SUV'),
(4, 'Renegade', 'Jeep', 2022, 'JKL3456', 'Vermelho', 'Manutenção', '180.00', 'SUV'),
(5, 'Onix', 'Chevrolet', 2021, 'MNO7890', 'Azul', 'Disponível', '120.00', 'Hatchback');

-- --------------------------------------------------------

--
-- Estrutura da tabela `catalogo`
--

CREATE TABLE IF NOT EXISTS `catalogo` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `marca` varchar(50) NOT NULL,
  `modelo` varchar(50) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=184 ;

--
-- Extraindo dados da tabela `catalogo`
--

INSERT INTO `catalogo` (`codigo`, `marca`, `modelo`) VALUES
(1, 'Toyota', 'Corolla'),
(2, 'Honda', 'Civic'),
(3, 'Ford', 'Mustang'),
(4, 'Chevrolet', 'Onix'),
(5, 'Volkswagen', 'Gol'),
(6, 'Fiat', 'Palio'),
(7, 'Hyundai', 'HB20'),
(8, 'Nissan', 'Versa'),
(9, 'Kia', 'Cerato'),
(10, 'Peugeot', '208'),
(11, 'Renault', 'Sandero'),
(12, 'Subaru', 'Impreza'),
(13, 'Mazda', '3'),
(14, 'Dodge', 'Charger'),
(15, 'Chrysler', '300C'),
(16, 'Jeep', 'Compass'),
(17, 'Audi', 'A3'),
(18, 'BMW', '320i'),
(19, 'Mercedes-Benz', 'C180'),
(20, 'Volvo', 'S60'),
(21, 'Land Rover', 'Evoque'),
(22, 'Porsche', 'Macan'),
(23, 'Lexus', 'IS300'),
(24, 'Mini', 'Cooper'),
(25, 'Fiat', '500'),
(26, 'Opel', 'Astra'),
(27, 'Skoda', 'Octavia'),
(28, 'Seat', 'Leon'),
(29, 'Mitsubishi', 'Lancer'),
(30, 'Suzuki', 'Vitara'),
(31, 'MG', 'ZS'),
(32, 'Lincoln', 'MKZ'),
(33, 'Tesla', 'Model 3'),
(34, 'Infiniti', 'Q50'),
(35, 'Acura', 'ILX'),
(36, 'Genesis', 'G70'),
(37, 'Alfa Romeo', 'Giulia'),
(38, 'Jaguar', 'XE'),
(39, 'Buick', 'Regal'),
(40, 'GMC', 'Terrain'),
(41, 'Honda', 'Fit'),
(42, 'Hyundai', 'Creta'),
(43, 'Toyota', 'RAV4'),
(44, 'Chevrolet', 'Tracker'),
(45, 'Ford', 'Edge'),
(46, 'Volkswagen', 'T-Cross'),
(47, 'Renault', 'Duster'),
(48, 'Nissan', 'Kicks'),
(49, 'Kia', 'Seltos'),
(50, 'Peugeot', '3008'),
(51, 'Mazda', 'CX-5'),
(52, 'Subaru', 'Forester'),
(53, 'Chrysler', 'Pacifica'),
(54, 'Dodge', 'Durango'),
(55, 'Toyota', 'Hilux'),
(56, 'Honda', 'CR-V'),
(57, 'Ford', 'F-150'),
(58, 'Chevrolet', 'Silverado'),
(59, 'Volkswagen', 'Amarok'),
(60, 'Nissan', 'Frontier'),
(61, 'Fiat', 'Toro'),
(62, 'Hyundai', 'Tucson'),
(63, 'Renault', 'Captur'),
(64, 'Kia', 'Sportage'),
(65, 'Peugeot', '5008'),
(66, 'Suzuki', 'S-Cross'),
(67, 'Mitsubishi', 'Outlander'),
(68, 'Subaru', 'Crosstrek'),
(69, 'GMC', 'Sierra'),
(70, 'Chevrolet', 'Equinox'),
(71, 'Ford', 'Explorer'),
(72, 'Toyota', '4Runner'),
(73, 'Honda', 'Pilot'),
(74, 'Mazda', 'CX-30'),
(75, 'Nissan', 'Rogue'),
(76, 'Volkswagen', 'Tiguan'),
(77, 'Fiat', 'Fiorino'),
(78, 'Renault', 'Kwid'),
(79, 'Hyundai', 'Venue'),
(80, 'Kia', 'Soul'),
(81, 'Peugeot', '208 GT'),
(82, 'BMW', 'X5'),
(83, 'Audi', 'Q5'),
(84, 'Mercedes-Benz', 'GLC'),
(85, 'Lexus', 'RX350'),
(86, 'Jaguar', 'F-Pace'),
(87, 'Porsche', 'Cayenne'),
(88, 'Volvo', 'XC60'),
(89, 'Land Rover', 'Discovery'),
(90, 'Tesla', 'Model Y'),
(91, 'Infiniti', 'QX60'),
(92, 'Acura', 'RDX'),
(93, 'Genesis', 'G80'),
(94, 'Alfa Romeo', 'Stelvio'),
(95, 'Mini', 'Countryman'),
(96, 'Subaru', 'Ascent'),
(97, 'Chrysler', 'Voyager'),
(98, 'Dodge', 'Challenger'),
(99, 'Buick', 'Envision'),
(100, 'GMC', 'Acadia'),
(101, 'Toyota', 'Camry'),
(102, 'Honda', 'Accord'),
(103, 'Ford', 'Fusion'),
(104, 'Chevrolet', 'Malibu'),
(105, 'Volkswagen', 'Jetta'),
(106, 'Hyundai', 'Sonata'),
(107, 'Nissan', 'Altima'),
(108, 'Kia', 'K5'),
(109, 'Mazda', '6'),
(110, 'Subaru', 'Legacy'),
(111, 'Chrysler', '300'),
(112, 'Dodge', 'Journey'),
(113, 'Toyota', 'Sienna'),
(114, 'Honda', 'Odyssey'),
(115, 'Ford', 'Transit'),
(116, 'Chevrolet', 'Express'),
(117, 'Ram', 'ProMaster'),
(118, 'Mercedes-Benz', 'Sprinter'),
(119, 'Nissan', 'NV3500'),
(120, 'GMC', 'Savana'),
(121, 'Hyundai', 'Ioniq'),
(122, 'Toyota', 'Prius'),
(123, 'Kia', 'Niro'),
(124, 'Ford', 'Maverick'),
(125, 'Chevrolet', 'Bolt'),
(126, 'Volkswagen', 'ID.4'),
(127, 'Porsche', 'Taycan'),
(128, 'Tesla', 'Model S'),
(129, 'BMW', 'i3'),
(130, 'Audi', 'e-tron'),
(131, 'Nissan', 'Leaf'),
(132, 'Hyundai', 'Kona Electric'),
(133, 'Kia', 'Soul EV'),
(134, 'Fiat', 'e-500'),
(135, 'Volkswagen', 'e-Golf'),
(136, 'Renault', 'Zoe'),
(137, 'BMW', 'iX'),
(138, 'Mercedes-Benz', 'EQC'),
(139, 'Ford', 'F-150 Lightning'),
(140, 'Rivian', 'R1T'),
(141, 'Lucid', 'Air'),
(142, 'Fisker', 'Ocean'),
(143, 'Faraday Future', 'FF 91'),
(144, 'Nissan', 'Ariya'),
(145, 'Honda', 'e'),
(146, 'Toyota', 'Mirai'),
(147, 'BMW', 'i4'),
(148, 'Volkswagen', 'ID.3'),
(149, 'Audi', 'Q4 e-tron'),
(150, 'Kia', 'EV6'),
(151, 'Hyundai', 'Ioniq 5'),
(152, 'Chevrolet', 'Equinox EV'),
(153, 'Ford', 'MUSTANG MACH-E'),
(154, 'Tesla', 'Cybertruck'),
(155, 'Toyota', 'Highlander'),
(156, 'Honda', 'Passport'),
(157, 'Nissan', 'Armada'),
(158, 'Ford', 'Expedition'),
(159, 'Chevrolet', 'Tahoe'),
(160, 'GMC', 'Yukon'),
(161, 'Cadillac', 'Escalade'),
(162, 'Toyota', 'Sequoia'),
(163, 'Jeep', 'Wrangler'),
(164, 'Land Rover', 'Defender'),
(165, 'Subaru', 'Outback'),
(166, 'Mazda', 'CX-9'),
(167, 'Hyundai', 'Palisade'),
(168, 'Kia', 'Telluride'),
(169, 'Volkswagen', 'Atlas'),
(170, 'Ford', 'Bronco'),
(171, 'Chevrolet', 'Blazer'),
(172, 'Dodge', 'Durango'),
(173, 'Toyota', 'Land Cruiser'),
(174, 'Honda', 'CR-V Hybrid'),
(175, 'Nissan', 'Rogue Hybrid'),
(176, 'Ford', 'Escape Hybrid'),
(177, 'Chevrolet', 'Equinox Hybrid'),
(178, 'Hyundai', 'Tucson Hybrid'),
(179, 'Kia', 'Sportage Hybrid'),
(180, 'Subaru', 'Crosstrek Hybrid'),
(181, 'Toyota', 'RAV4 Hybrid'),
(182, 'Volkswagen', 'Tiguan Hybrid'),
(183, 'Mazda', 'CX-30 Hybrid');

-- --------------------------------------------------------

--
-- Estrutura da tabela `clientes`
--

CREATE TABLE IF NOT EXISTS `clientes` (
  `cliente_id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `cpf` varchar(14) NOT NULL,
  `telefone` varchar(15) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `endereco` varchar(255) DEFAULT NULL,
  `data_nascimento` date DEFAULT NULL,
  PRIMARY KEY (`cliente_id`),
  UNIQUE KEY `cpf` (`cpf`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Extraindo dados da tabela `clientes`
--

INSERT INTO `clientes` (`cliente_id`, `nome`, `cpf`, `telefone`, `email`, `endereco`, `data_nascimento`) VALUES
(1, 'João Silva', '123.456.789-00', '(11) 99999-1111', 'joao.silva@email.com', 'Rua A, 123, São Paulo, SP', '1990-05-10'),
(2, 'Maria Oliveira', '987.654.321-00', '(21) 98888-2222', 'maria.oliveira@email.com', 'Av. B, 456, Rio de Janeiro, RJ', '1985-03-15'),
(3, 'Carlos Pereira', '456.789.123-00', '(31) 97777-3333', 'carlos.pereira@email.com', 'Rua C, 789, Belo Horizonte, MG', '1992-07-25'),
(4, 'Ana Souza', '321.654.987-00', '(41) 96666-4444', 'ana.souza@email.com', 'Av. D, 101, Curitiba, PR', '1988-12-05'),
(5, 'Paulo Lima', '654.987.321-00', '(51) 95555-5555', 'paulo.lima@email.com', 'Rua E, 202, Porto Alegre, RS', '1978-11-20');

-- --------------------------------------------------------

--
-- Estrutura da tabela `funcionarios`
--

CREATE TABLE IF NOT EXISTS `funcionarios` (
  `funcionario_id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `cpf` varchar(14) NOT NULL,
  `telefone` varchar(15) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `cargo` varchar(50) NOT NULL,
  `salario` decimal(10,2) NOT NULL,
  `data_admissao` date NOT NULL,
  PRIMARY KEY (`funcionario_id`),
  UNIQUE KEY `cpf` (`cpf`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Extraindo dados da tabela `funcionarios`
--

INSERT INTO `funcionarios` (`funcionario_id`, `nome`, `cpf`, `telefone`, `email`, `cargo`, `salario`, `data_admissao`) VALUES
(1, 'Ricardo Costa', '159.753.486-00', '(11) 94444-1111', 'ricardo.costa@email.com', 'Gerente', '5000.00', '2020-01-10'),
(2, 'Fernanda Alves', '258.369.147-00', '(21) 93333-2222', 'fernanda.alves@email.com', 'Atendente', '2500.00', '2019-03-20'),
(3, 'Lucas Martins', '357.951.852-00', '(31) 92222-3333', 'lucas.martins@email.com', 'Atendente', '2400.00', '2021-05-30'),
(4, 'Camila Santos', '654.321.987-00', '(41) 91111-4444', 'camila.santos@email.com', 'Gerente', '5200.00', '2018-07-15'),
(5, 'Rafael Lima', '789.456.123-00', '(51) 90000-5555', 'rafael.lima@email.com', 'Mecânico', '3000.00', '2022-02-25');

-- --------------------------------------------------------

--
-- Estrutura da tabela `locacoes`
--

CREATE TABLE IF NOT EXISTS `locacoes` (
  `locacao_id` int(11) NOT NULL AUTO_INCREMENT,
  `carro_id` int(11) DEFAULT NULL,
  `cliente_id` int(11) DEFAULT NULL,
  `data_inicio` date NOT NULL,
  `data_fim` date NOT NULL,
  `valor_total` varchar(10) NOT NULL,
  `status` varchar(20) NOT NULL,
  PRIMARY KEY (`locacao_id`),
  KEY `carro_id` (`carro_id`),
  KEY `cliente_id` (`cliente_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=16 ;

--
-- Extraindo dados da tabela `locacoes`
--

INSERT INTO `locacoes` (`locacao_id`, `carro_id`, `cliente_id`, `data_inicio`, `data_fim`, `valor_total`, `status`) VALUES
(1, 1, 1, '2023-08-01', '2023-08-10', '1500.00', 'Finalizada'),
(2, 2, 2, '2023-08-05', '2023-08-15', '1600.00', 'Finalizada'),
(3, 3, 3, '2023-08-10', '2023-08-20', '1400.00', 'Ativa'),
(4, 4, 4, '2023-08-15', '2023-08-25', '1800.00', 'Cancelada'),
(5, 5, 5, '2023-08-20', '2023-08-30', '1200.00', 'Ativa'),
(11, 1, 1, '0000-00-00', '0000-00-00', ' R$ 450,00', 'Cancelado'),
(12, 1, 4, '0000-00-00', '0000-00-00', ' R$ 4.950,', 'Ativa'),
(13, 2, 2, '0000-00-00', '0000-00-00', ' R$ 1.280,', 'Finalizada'),
(14, 0, 0, '2024-10-22', '2024-10-25', '450', 'Ativa'),
(15, 0, 0, '2024-10-06', '2024-11-09', '5100', 'Ativa');

-- --------------------------------------------------------

--
-- Estrutura da tabela `manutencoes`
--

CREATE TABLE IF NOT EXISTS `manutencoes` (
  `manutencao_id` int(11) NOT NULL AUTO_INCREMENT,
  `carro_id` int(11) DEFAULT NULL,
  `data_inicio` date NOT NULL,
  `data_fim` date DEFAULT NULL,
  `descricao` text NOT NULL,
  `custo` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`manutencao_id`),
  KEY `carro_id` (`carro_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Extraindo dados da tabela `manutencoes`
--

INSERT INTO `manutencoes` (`manutencao_id`, `carro_id`, `data_inicio`, `data_fim`, `descricao`, `custo`) VALUES
(1, 1, '2023-07-01', '2023-07-05', 'Troca de óleo e revisão geral', '300.00'),
(2, 2, '2023-07-10', '2023-07-12', 'Substituição de pneus', '800.00'),
(3, 3, '2023-07-15', '2023-07-20', 'Reparação de motor', '1500.00'),
(4, 4, '2023-07-22', '2023-07-25', 'Troca de bateria', '400.00'),
(5, 5, '2023-07-28', '2023-07-30', 'Revisão de freios', '600.00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `multas`
--

CREATE TABLE IF NOT EXISTS `multas` (
  `multa_id` int(11) NOT NULL AUTO_INCREMENT,
  `locacao_id` int(11) DEFAULT NULL,
  `carro_id` int(11) DEFAULT NULL,
  `data_infracao` date NOT NULL,
  `descricao` text NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  PRIMARY KEY (`multa_id`),
  KEY `locacao_id` (`locacao_id`),
  KEY `carro_id` (`carro_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Extraindo dados da tabela `multas`
--

INSERT INTO `multas` (`multa_id`, `locacao_id`, `carro_id`, `data_infracao`, `descricao`, `valor`) VALUES
(1, 1, 1, '2023-08-02', 'Excesso de velocidade', '300.00'),
(2, 2, 2, '2023-08-06', 'Estacionamento proibido', '150.00'),
(3, 3, 3, '2023-08-12', 'Uso de celular ao volante', '200.00'),
(4, 4, 4, '2023-08-18', 'Avanço de sinal vermelho', '250.00'),
(5, 5, 5, '2023-08-22', 'Estacionamento em vaga de deficiente', '400.00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `pagamentos`
--

CREATE TABLE IF NOT EXISTS `pagamentos` (
  `pagamento_id` int(11) NOT NULL AUTO_INCREMENT,
  `locacao_id` int(11) DEFAULT NULL,
  `cliente_id` int(11) DEFAULT NULL,
  `data_pagamento` date NOT NULL,
  `valor_pago` varchar(10) NOT NULL,
  `metodo_pagamento` varchar(50) NOT NULL,
  PRIMARY KEY (`pagamento_id`),
  KEY `locacao_id` (`locacao_id`),
  KEY `cliente_id` (`cliente_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=10 ;

--
-- Extraindo dados da tabela `pagamentos`
--

INSERT INTO `pagamentos` (`pagamento_id`, `locacao_id`, `cliente_id`, `data_pagamento`, `valor_pago`, `metodo_pagamento`) VALUES
(1, 1, 1, '2023-08-10', '1500.00', 'Cartão de Crédito'),
(2, 2, 2, '2023-08-15', '1600.00', 'Dinheiro'),
(3, 3, 3, '2023-08-20', '700.00', 'Transferência'),
(4, 4, 4, '2023-08-25', '900.00', 'Cartão de Débito'),
(5, 5, 5, '2023-08-30', '1200.00', 'Pix'),
(6, 0, 1, '0000-00-00', ' R$ 3.300,', 'Pix'),
(7, 11, 1, '0000-00-00', ' R$ 450,00', 'Pix'),
(8, 0, 1, '0000-00-00', ' R$ 4.950,', 'Pix'),
(9, 13, 2, '0000-00-00', ' R$ 1.280,', 'Pix');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuarios`
--

CREATE TABLE IF NOT EXISTS `usuarios` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(200) NOT NULL,
  `email` varchar(200) NOT NULL,
  `senha` varchar(200) NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=8 ;

--
-- Extraindo dados da tabela `usuarios`
--

INSERT INTO `usuarios` (`codigo`, `nome`, `email`, `senha`) VALUES
(1, 'Ester de Almeida Girotto', 'estergirotto775@gmail.com', '123'),
(2, 'Lua', 'lovegoodlua115@gmail.com', 'tanque26'),
(3, 'davi', 'davii@gmail.com', '123'),
(5, 'Lua', 'lua@gmail.com', '202cb962ac59075b964b07152d234b70'),
(6, 'Teste', '123', '202cb962ac59075b964b07152d234b70'),
(7, 'a12', '321', '202cb962ac59075b964b07152d234b70');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
