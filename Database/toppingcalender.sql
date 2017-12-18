-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 15, 2017 at 04:46 AM
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
('aa', 'aa', 'aa', '2017-12-11', 1, 'USR004', '2017-12-11', 'USR004', '2017-12-11'),
('test00', 'test33', 'test12', '2017-12-11', 1, 'USR004', '2017-12-11', 'USR004', '2017-12-11');

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
  `Updated_by` int(11) NOT NULL,
  `Updated_Date` varchar(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `machine_productions`
--

INSERT INTO `machine_productions` (`MachineCode`, `Description`, `IsActive`, `Created_by`, `Created_Date`, `Updated_by`, `Updated_Date`) VALUES
('mc0001', 'test', 1, 'USR004', '2017-12-11', 0, '2017-1'),
('mc889', 'test234', 0, 'USR004', '2017-12-11', 0, '2017-1');

-- --------------------------------------------------------

--
-- Table structure for table `numbersspec`
--

CREATE TABLE IF NOT EXISTS `numbersspec` (
  `NumberSpec` varchar(6) NOT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `product1` decimal(10,0) NOT NULL,
  `product2` decimal(10,0) NOT NULL,
  `product3` decimal(10,0) NOT NULL,
  `product4` decimal(10,0) NOT NULL,
  `process1` decimal(10,0) NOT NULL,
  `process2` decimal(10,0) NOT NULL,
  `process3` decimal(10,0) NOT NULL,
  `process4` decimal(10,0) NOT NULL,
  `process5` decimal(10,0) NOT NULL,
  `process6` decimal(10,0) NOT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `Created_by` varchar(6) NOT NULL,
  `Created_Date` date NOT NULL,
  `Updated_by` varchar(6) NOT NULL,
  `Updated_Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
('888u', 'yyy', 'yyyyyy', 1, 'USR004', '2017-12-11', 'USR004', '2017-12-11'),
('gggh', 'hhhh', 'hhhhhh', 1, 'USR004', '2017-12-11', 'USR004', '2017-12-11'),
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
  `Actual` decimal(10,0) DEFAULT NULL,
  `QtyMeter` decimal(10,0) NOT NULL,
  `Information` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `productions`
--

CREATE TABLE IF NOT EXISTS `productions` (
  `ProductionCode` varchar(15) NOT NULL,
  `ProductionDate` date NOT NULL,
  `ExpDate` date NOT NULL,
  `ScheduleCode` varchar(15) NOT NULL,
  `Shift` int(11) NOT NULL,
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
  `TreatmentCode` varchar(6) NOT NULL,
  `ConsDay` decimal(10,0) NOT NULL,
  `ConsShift` decimal(10,0) NOT NULL,
  `MachineCode` varchar(6) NOT NULL,
  `ExpectedSpeed` int(11) NOT NULL,
  `ActualSpeedshift1` decimal(10,0) DEFAULT NULL,
  `ConsShift1` decimal(10,0) NOT NULL,
  `SCHRollShift1` decimal(10,0) DEFAULT NULL,
  `rollshift1` decimal(10,0) DEFAULT NULL,
  `metershift1` decimal(10,0) DEFAULT NULL,
  `descshift1` varchar(100) DEFAULT NULL,
  `ActualSpeedshift2` decimal(10,0) DEFAULT NULL,
  `ConsShift2` decimal(10,0) DEFAULT NULL,
  `SCHRollShift2` decimal(10,0) DEFAULT NULL,
  `rollshift2` decimal(10,0) DEFAULT NULL,
  `metershift2` decimal(10,0) DEFAULT NULL,
  `descshift2` varchar(100) DEFAULT NULL,
  `ActualSpeedshift3` decimal(10,0) DEFAULT NULL,
  `ConsShift3` decimal(10,0) NOT NULL,
  `SCHRollShift3` decimal(10,0) DEFAULT NULL,
  `rollshift3` decimal(10,0) DEFAULT NULL,
  `metershift3` decimal(10,0) DEFAULT NULL,
  `descshift3` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `schedules`
--

CREATE TABLE IF NOT EXISTS `schedules` (
  `ScheduleCode` varchar(15) NOT NULL,
  `SheduleDate` date NOT NULL,
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
  `SPL` decimal(10,0) DEFAULT NULL,
  `ST` decimal(10,0) DEFAULT NULL,
  `MP` decimal(10,0) DEFAULT NULL,
  `BT` decimal(10,0) DEFAULT NULL,
  `OC` decimal(10,0) DEFAULT NULL,
  `SG` decimal(10,0) DEFAULT NULL,
  `SC` decimal(10,0) DEFAULT NULL,
  `LR` decimal(10,0) DEFAULT NULL,
  `KP` decimal(10,0) DEFAULT NULL,
  `LL` decimal(10,0) DEFAULT NULL,
  `TTL` decimal(10,0) DEFAULT NULL,
  `ProdMeter` decimal(10,0) DEFAULT NULL,
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
('tr899', 'test2', 1, 'USR004', '2017-12-11', 'USR004', '2017-12-11'),
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
('USR001', 'test', 'O/e+aAh8xmw=', 'Admin', 1, 'System', '2017-12-07', 'System', '2017-12-07'),
('USR002', 'test', 'u9g2WZEC0y0=', 'Leader', 0, 'System', '2017-12-07', 'test', '2017-12-07'),
('USR003', 'tiar', 'O/e+aAh8xmw=', 'Leader', 1, 'System', '2017-12-10', 'USR003', '2017-12-10'),
('USR004', 'apip', 'EpqDw4oz7S8=', 'Admin', 1, 'System', '2017-12-10', 'System', '2017-12-10'),
('USR005', 'alan', 'gGfYdFNiK1A=', 'Production', 1, 'System', '2017-12-10', 'System', '2017-12-10');

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
