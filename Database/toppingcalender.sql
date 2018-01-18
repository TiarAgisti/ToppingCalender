-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jan 17, 2018 at 12:50 PM
-- Server version: 5.6.21
-- PHP Version: 5.5.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `toppingcalender`
--

-- --------------------------------------------------------

--
-- Table structure for table `compounts`
--

CREATE TABLE IF NOT EXISTS `compounts` (
  `CompountCode` varchar(6) NOT NULL,
  `CompountBatch` varchar(25) NOT NULL,
  `CompountDesc` varchar(50) NOT NULL,
  `CompountExpdate` date NOT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `Created_by` varchar(6) NOT NULL,
  `Created_Date` date NOT NULL,
  `Updated_by` varchar(6) NOT NULL,
  `Updated_Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `compounts`
--

INSERT INTO `compounts` (`CompountCode`, `CompountBatch`, `CompountDesc`, `CompountExpdate`, `IsActive`, `Created_by`, `Created_Date`, `Updated_by`, `Updated_Date`) VALUES
('aa', 'aa', 'aa', '2017-12-11', 0, 'USR004', '2017-12-11', 'USR004', '2018-01-16'),
('AC121', '1-3', '8/1/A/5', '2018-01-12', 1, 'USR004', '2018-01-16', 'USR004', '2018-01-17'),
('AC140', '4-3', '10/1/A/5', '2018-01-14', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('AC150', '5-8', '7/1/C/7', '2018-01-12', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('AC180', '10-13', '14/1/D/4', '2018-01-18', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('AC195', '12-15', '12/1/A/3', '2018-01-16', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('test00', 'test33', 'test12', '2017-12-11', 0, 'USR004', '2017-12-11', 'USR004', '2018-01-16');

-- --------------------------------------------------------

--
-- Table structure for table `machine_productions`
--

CREATE TABLE IF NOT EXISTS `machine_productions` (
  `MachineCode` varchar(6) NOT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `Created_by` varchar(6) NOT NULL,
  `Created_Date` date NOT NULL,
  `Updated_by` varchar(6) NOT NULL,
  `Updated_Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `machine_productions`
--

INSERT INTO `machine_productions` (`MachineCode`, `Description`, `IsActive`, `Created_by`, `Created_Date`, `Updated_by`, `Updated_Date`) VALUES
('ACL', '0K', 0, 'USR004', '2018-01-16', '0', '0000-00-00'),
('ACL1', 'OK', 0, 'USR004', '2018-01-16', '0', '0000-00-00'),
('ACLa', 'OK', 1, 'USR004', '2018-01-17', '0', '0000-00-00'),
('ACLb', 'ok untuk produksi', 1, 'USR004', '2018-01-17', '0', '0000-00-00'),
('mc0001', 'test', 0, 'USR004', '2017-12-11', '0', '0000-00-00'),
('mc889', 'test234', 0, 'USR004', '2017-12-11', '0', '0000-00-00'),
('MCH1', 'Machine 1', 0, 'USR001', '2018-01-10', '0', '0000-00-00');

-- --------------------------------------------------------

--
-- Table structure for table `numbersspec`
--

CREATE TABLE IF NOT EXISTS `numbersspec` (
  `NumberSpec` varchar(8) NOT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `product1` decimal(10,2) NOT NULL,
  `product2` decimal(10,2) NOT NULL,
  `product3` decimal(10,2) NOT NULL,
  `product4` decimal(10,2) NOT NULL,
  `process1` decimal(10,2) NOT NULL,
  `process2` decimal(10,2) NOT NULL,
  `process3` decimal(10,2) NOT NULL,
  `process4` decimal(10,2) NOT NULL,
  `process5` decimal(10,2) NOT NULL,
  `process6` decimal(10,2) NOT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `Created_by` varchar(6) NOT NULL,
  `Created_Date` date NOT NULL,
  `Updated_by` varchar(6) NOT NULL,
  `Updated_Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `numbersspec`
--

INSERT INTO `numbersspec` (`NumberSpec`, `Description`, `product1`, `product2`, `product3`, `product4`, `process1`, `process2`, `process3`, `process4`, `process5`, `process6`, `IsActive`, `Created_by`, `Created_Date`, `Updated_by`, `Updated_Date`) VALUES
('NumSpe', 'Number Spec 1 Update', '1.00', '2.00', '3.00', '4.00', '5.00', '6.00', '7.00', '8.00', '9.00', '10.00', 0, 'USR001', '2018-01-11', 'USR004', '2018-01-16'),
('TC008-01', 'GTTC', '1.00', '1.00', '1.00', '1460.00', '85.00', '90.00', '90.00', '85.00', '600.00', '600.00', 1, '', '2018-01-17', '', '2018-01-17'),
('TC011-01', 'GTTC', '1.00', '1.00', '1.00', '1460.00', '85.00', '90.00', '90.00', '85.00', '950.00', '950.00', 1, 'USR004', '2018-01-16', 'USR004', '2018-01-17'),
('TC013-01', 'GTTC', '1.00', '1.00', '1.00', '1460.00', '85.00', '90.00', '90.00', '85.00', '750.00', '750.00', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('TCO19-01', 'GTTC', '1.00', '1.00', '1.00', '1460.00', '85.00', '90.00', '90.00', '85.00', '850.00', '850.00', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('test', 'test', '1.00', '2.00', '3.00', '4.00', '5.00', '6.00', '7.00', '8.00', '9.00', '10.00', 0, 'USR001', '2018-01-11', 'USR001', '2018-01-11');

-- --------------------------------------------------------

--
-- Table structure for table `nylon`
--

CREATE TABLE IF NOT EXISTS `nylon` (
  `NylonCode` varchar(6) NOT NULL,
  `NoRollNylon` varchar(20) NOT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `Created_by` varchar(6) NOT NULL,
  `Created_Date` date NOT NULL,
  `Updated_by` varchar(6) NOT NULL,
  `Updated_Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `nylon`
--

INSERT INTO `nylon` (`NylonCode`, `NoRollNylon`, `Description`, `IsActive`, `Created_by`, `Created_Date`, `Updated_by`, `Updated_Date`) VALUES
('604', '512', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('888u', 'yyy', 'yyyyyy', 0, 'USR004', '2017-12-11', 'USR004', '2018-01-16'),
('F6127', '7314569', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('F6137', '7384613', 'OK', 0, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('F6137W', '7398612', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('F6138J', '7356731', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('F6141*', '7314151', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('F6141J', '7314142', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('F6143J', '7211176', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('F6144W', '735891', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('F6146J', '7355651', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('F6151J', '7314419', 'OK', 1, 'USR004', '2018-01-16', 'USR004', '2018-01-16'),
('F6155J', '7311789', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('F6158J', '7311711', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('F7130N', '7314562', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('gggh', 'hhhh', 'hhhhhh', 0, 'USR004', '2017-12-11', 'USR004', '2018-01-16'),
('J6151J', '7215146', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('uuii', 'test11', 'testtttttssss', 0, 'USR004', '2017-12-11', 'USR004', '2017-12-11');

-- --------------------------------------------------------

--
-- Table structure for table `productiondetails`
--

CREATE TABLE IF NOT EXISTS `productiondetails` (
  `ProductionCode` varchar(15) NOT NULL,
  `NoRoll` int(11) NOT NULL,
  `TreatmentCode` varchar(10) NOT NULL,
  `NumberSpec` varchar(15) NOT NULL,
  `Supplier` varchar(15) NOT NULL,
  `NylonCode` varchar(6) NOT NULL,
  `DateInNylon` date NOT NULL,
  `CompountCode` varchar(6) NOT NULL,
  `Sign` varchar(2) DEFAULT NULL,
  `Actual` decimal(10,2) DEFAULT NULL,
  `QtyMeter` decimal(10,2) NOT NULL,
  `Information` varchar(100) DEFAULT NULL,
  `Month` int(20) NOT NULL,
  `Year` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `productions`
--

CREATE TABLE IF NOT EXISTS `productions` (
  `ProductionCode` varchar(15) NOT NULL,
  `ProductionDate` date NOT NULL,
  `ExpDate` date NOT NULL,
  `Shift` int(11) DEFAULT NULL,
  `ScheduleCode` varchar(15) NOT NULL,
  `Status` int(11) NOT NULL,
  `Created_by` varchar(6) NOT NULL,
  `Created_Date` date NOT NULL,
  `Updated_by` varchar(6) NOT NULL,
  `Updated_Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `scheduledetails`
--

CREATE TABLE IF NOT EXISTS `scheduledetails` (
  `ScheduleCode` varchar(15) NOT NULL,
  `TreatmentCode` varchar(10) NOT NULL,
  `ConsDay` decimal(10,2) NOT NULL,
  `ConsShift` decimal(10,2) NOT NULL,
  `MachineCode` varchar(6) NOT NULL,
  `ExpectedSpeed` int(11) NOT NULL,
  `ActualSpeedshift1` decimal(10,2) DEFAULT NULL,
  `ConsShift1` decimal(10,2) DEFAULT NULL,
  `SCHRollShift1` decimal(10,2) DEFAULT NULL,
  `rollshift1` decimal(10,2) DEFAULT NULL,
  `metershift1` decimal(10,2) DEFAULT NULL,
  `descshift1` varchar(100) DEFAULT NULL,
  `ActualSpeedshift2` decimal(10,2) DEFAULT NULL,
  `ConsShift2` decimal(10,2) DEFAULT NULL,
  `SCHRollShift2` decimal(10,2) DEFAULT NULL,
  `rollshift2` decimal(10,2) DEFAULT NULL,
  `metershift2` decimal(10,2) DEFAULT NULL,
  `descshift2` varchar(100) DEFAULT NULL,
  `ActualSpeedshift3` decimal(10,2) DEFAULT NULL,
  `ConsShift3` decimal(10,2) DEFAULT NULL,
  `SCHRollShift3` decimal(10,2) DEFAULT NULL,
  `rollshift3` decimal(10,2) DEFAULT NULL,
  `metershift3` decimal(10,2) DEFAULT NULL,
  `descshift3` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `schedules`
--

CREATE TABLE IF NOT EXISTS `schedules` (
  `ScheduleCode` varchar(15) NOT NULL,
  `ScheduleDate` date NOT NULL,
  `Revision` int(11) NOT NULL,
  `Status` int(11) NOT NULL,
  `Created_by` varchar(6) NOT NULL,
  `Created_Date` date NOT NULL,
  `Updated_by` varchar(6) NOT NULL,
  `Updated_Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `scrapproductiondetails`
--

CREATE TABLE IF NOT EXISTS `scrapproductiondetails` (
  `ScrapCode` varchar(15) NOT NULL,
  `TreatmentCode` varchar(10) NOT NULL,
  `NoRoll` int(11) NOT NULL,
  `SPL` decimal(10,2) DEFAULT NULL,
  `ST` decimal(10,2) DEFAULT NULL,
  `MP` decimal(10,2) DEFAULT NULL,
  `BT` decimal(10,2) DEFAULT NULL,
  `OC` decimal(10,2) DEFAULT NULL,
  `SG` decimal(10,2) DEFAULT NULL,
  `SC` decimal(10,2) DEFAULT NULL,
  `LR` decimal(10,2) DEFAULT NULL,
  `KP` decimal(10,2) DEFAULT NULL,
  `LL` decimal(10,2) DEFAULT NULL,
  `TTL` decimal(10,2) DEFAULT NULL,
  `ProdMeter` decimal(10,2) DEFAULT NULL,
  `NumberLiner` int(11) DEFAULT NULL,
  `Description` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `scrapproductions`
--

CREATE TABLE IF NOT EXISTS `scrapproductions` (
  `ScrapCode` varchar(15) NOT NULL,
  `ScrapDate` date NOT NULL,
  `MachineCode` varchar(6) NOT NULL,
  `Shift` int(11) NOT NULL,
  `ProductionCode` varchar(15) NOT NULL,
  `Status` int(11) NOT NULL,
  `Created_by` varchar(6) NOT NULL,
  `Created_Date` date NOT NULL,
  `Updated_by` varchar(6) NOT NULL,
  `Updated_Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `treatment`
--

CREATE TABLE IF NOT EXISTS `treatment` (
  `TreatmentCode` varchar(10) NOT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `Created_by` varchar(6) NOT NULL,
  `Created_Date` date NOT NULL,
  `Updated_by` varchar(6) NOT NULL,
  `Updated_Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `treatment`
--

INSERT INTO `treatment` (`TreatmentCode`, `Description`, `IsActive`, `Created_by`, `Created_Date`, `Updated_by`, `Updated_Date`) VALUES
('A27N-150', 'OK', 1, 'USR004', '2018-01-17', '', '2018-01-17'),
('A30N-150', 'OK', 1, 'USR004', '2018-01-16', 'USR004', '2018-01-16'),
('A30N-Y180', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('A37W-121', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('A38J-150', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('A38J-W121', 'OK', 1, 'USR004', '2018-01-16', 'USR004', '2018-01-16'),
('A41J-150', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('A41J-V140', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('A41J-V140*', '2nd Grade', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('A44W-121', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('A46J-W121', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('A51J-150', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('A51J-W121', '0K', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('A55J-V121', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('A55J-W121', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('A58J-W121', 'OK', 1, 'USR004', '2018-01-16', 'USR004', '2018-01-16'),
('A604-180', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('A604W-195', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('A604Y-195', 'OK', 1, 'USR004', '2018-01-17', 'USR004', '2018-01-17'),
('tr899', 'test2', 0, 'USR004', '2017-12-11', 'USR004', '2018-01-16'),
('ty001', 'test345', 0, 'USR004', '2017-12-11', 'USR004', '2017-12-11');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `UserCode` varchar(6) NOT NULL,
  `UserName` varchar(50) NOT NULL,
  `UserPassword` varchar(255) NOT NULL,
  `AccessLevel` varchar(25) NOT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `Created_by` varchar(6) NOT NULL,
  `Created_Date` date NOT NULL,
  `Updated_by` varchar(6) NOT NULL,
  `Updated_Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserCode`, `UserName`, `UserPassword`, `AccessLevel`, `IsActive`, `Created_by`, `Created_Date`, `Updated_by`, `Updated_Date`) VALUES
('USR001', 'agus', 'tOub3jRLlUo=', 'Admin', 1, 'System', '2018-01-08', 'System', '2018-01-08'),
('USR002', 'sholeh', 'tOub3jRLlUo=', 'Leader', 1, 'System', '2018-01-16', 'System', '2018-01-16'),
('USR003', 'andi', 'tOub3jRLlUo=', 'Production', 1, 'System', '2018-01-16', 'System', '2018-01-16'),
('USR004', 'dede', 'tOub3jRLlUo=', 'PPC', 1, 'System', '2018-01-16', 'System', '2018-01-16');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `compounts`
--
ALTER TABLE `compounts`
 ADD PRIMARY KEY (`CompountCode`);

--
-- Indexes for table `machine_productions`
--
ALTER TABLE `machine_productions`
 ADD PRIMARY KEY (`MachineCode`);

--
-- Indexes for table `numbersspec`
--
ALTER TABLE `numbersspec`
 ADD PRIMARY KEY (`NumberSpec`);

--
-- Indexes for table `nylon`
--
ALTER TABLE `nylon`
 ADD PRIMARY KEY (`NylonCode`);

--
-- Indexes for table `productiondetails`
--
ALTER TABLE `productiondetails`
 ADD PRIMARY KEY (`ProductionCode`,`NoRoll`);

--
-- Indexes for table `productions`
--
ALTER TABLE `productions`
 ADD PRIMARY KEY (`ProductionCode`);

--
-- Indexes for table `scheduledetails`
--
ALTER TABLE `scheduledetails`
 ADD PRIMARY KEY (`ScheduleCode`,`TreatmentCode`);

--
-- Indexes for table `schedules`
--
ALTER TABLE `schedules`
 ADD PRIMARY KEY (`ScheduleCode`);

--
-- Indexes for table `scrapproductiondetails`
--
ALTER TABLE `scrapproductiondetails`
 ADD PRIMARY KEY (`ScrapCode`,`TreatmentCode`);

--
-- Indexes for table `scrapproductions`
--
ALTER TABLE `scrapproductions`
 ADD PRIMARY KEY (`ScrapCode`);

--
-- Indexes for table `treatment`
--
ALTER TABLE `treatment`
 ADD PRIMARY KEY (`TreatmentCode`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
 ADD PRIMARY KEY (`UserCode`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
