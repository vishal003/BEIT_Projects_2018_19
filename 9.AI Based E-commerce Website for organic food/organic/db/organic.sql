-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Apr 10, 2019 at 11:21 AM
-- Server version: 10.1.30-MariaDB
-- PHP Version: 7.2.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `organic`
--

-- --------------------------------------------------------

--
-- Table structure for table `addproduct`
--

CREATE TABLE `addproduct` (
  `product_id` int(11) NOT NULL,
  `farmer_id` int(10) NOT NULL,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `product_image` varchar(500) NOT NULL,
  `newname` varchar(100) NOT NULL,
  `file_type` varchar(100) NOT NULL,
  `file_size` int(100) NOT NULL,
  `product_title` varchar(100) NOT NULL,
  `quantity` int(100) NOT NULL,
  `units` varchar(100) NOT NULL,
  `product_price` int(100) NOT NULL,
  `product_cat` varchar(100) NOT NULL,
  `product_desc` varchar(300) NOT NULL,
  `status` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `addproduct`
--

INSERT INTO `addproduct` (`product_id`, `farmer_id`, `date`, `product_image`, `newname`, `file_type`, `file_size`, `product_title`, `quantity`, `units`, `product_price`, `product_cat`, `product_desc`, `status`) VALUES
(108, 16, '2019-03-29 18:43:09', 'flower.jpg', '5c5980461ca6e.jpg', 'image/jpeg', 1042995, 'Flower', 10, 'Kg', 20, 'Vegitables', 'flower vegitables', 'approved'),
(110, 16, '2019-03-20 04:59:29', 'mango.jpg', '5c5980a081923.jpg', 'image/jpeg', 6890, 'Mango', 20, 'Kg', 25, 'Fruits', 'mango fruits', 'approved'),
(112, 16, '2019-03-29 18:43:01', 'orange.jpg', '5c5980d5a654c.jpg', 'image/jpeg', 8527, 'Orange', 30, 'Kg', 35, 'Fruits', 'fruits orange', 'approved'),
(114, 16, '2019-04-05 05:40:13', 'onion.png', '5c598112d0bf8.png', 'image/png', 62398, 'Onion', 40, 'Kg', 20, 'Vegetables', 'vegetables onions', 'approved'),
(124, 10, '2019-04-05 05:40:22', 'potato.jpg', '5c5985793b8fc.jpg', 'image/jpeg', 4356, 'Potato', 50, 'Kg', 10, 'Vegetables', 'vegetables potato', 'approved'),
(126, 10, '2019-04-05 05:40:29', 'tomato.jpg', '5c5985b664742.jpg', 'image/jpeg', 7415, 'Tomato', 30, 'Kg', 45, 'Vegetables', 'vegetables tomato', 'approved'),
(128, 10, '2019-04-05 05:40:37', 'bittergoud.jpg', '5c598719387d8.jpg', 'image/jpeg', 9084, 'Bitter gourd', 10, 'Kg', 24, 'Vegetables', 'bittergoud vegetables', 'approved'),
(130, 10, '2019-04-05 05:38:00', 'brinjal.jpeg', '5c5987648d6b5.jpeg', 'image/jpeg', 6851, 'Brinjal', 25, 'Kg', 13, 'Vegetables', 'brinjal vegitables', 'approved'),
(134, 10, '2019-04-05 05:40:47', 'carrot.jpeg', '5c59883b43785.jpeg', 'image/jpeg', 9441, 'Carrot', 50, 'Kg', 40, 'Vegetables', 'vegetales carrot', 'approved'),
(137, 17, '2019-04-05 05:46:53', 'chickoo.jpeg', '5c5988d37b953.jpeg', 'image/jpeg', 4916, 'Chikoo', 24, 'Kg', 55, 'Fruits', 'chickoo fruits', 'approved'),
(145, 17, '2019-04-05 05:40:55', 'greenpeas.jpg', '5c598a0a4882f.jpg', 'image/jpeg', 5582, 'Green peas', 18, 'Kg', 65, 'Vegetables', 'greenpeas vegetables', 'approved'),
(147, 17, '2019-02-17 10:11:10', 'jamun.jpg', '5c598a45693c1.jpg', 'image/jpeg', 22105, 'Jamun', 5, 'Kg', 15, 'Fruits', 'jamun fruitd', 'approved'),
(149, 17, '2019-02-17 10:11:14', 'jawari.jpg', '5c598aba8f59f.jpg', 'image/jpeg', 8225, 'Jaweri', 50, 'Ton', 10, 'Grains', 'jawari grains', 'approved'),
(156, 18, '2019-04-05 05:41:04', 'lemon.jpeg', '5c598c498ec48.jpeg', 'image/jpeg', 6911, 'Lemon', 10, 'Kg', 26, 'Vegetables', 'vegetables lemon', 'approved'),
(158, 18, '2019-02-17 09:57:05', 'millet.jpg', '5c598c9156b7d.jpg', 'image/jpeg', 18384, 'Millet', 30, 'Ton', 12, 'Grains', 'grains millet', 'approved'),
(162, 18, '2019-03-29 18:42:51', 'pineapple.jpeg', '5c598cea8f9f0.jpeg', 'image/jpeg', 7062, 'PineApple', 30, 'Kg', 30, 'Fruits', 'pineapple fruits', 'approved'),
(165, 18, '2019-03-29 07:16:26', 'rice.jpg', '5c598d5085575.jpg', 'image/jpeg', 5331, 'Rice', 45, 'Ton', 13, 'grains', 'rice grains', 'approved'),
(167, 18, '2019-03-31 18:25:19', 'strawberry.jpg', '5c598d8e05bd5.jpg', 'image/jpeg', 17235, 'StrawBerry', 10, 'Grams', 22, 'Fruits', 'strawerry fruits', 'approved'),
(185, 16, '2019-03-31 18:17:20', 'grapes.jpg', '5ca103ec6152f.jpg', 'image/jpeg', 5509, 'Grapes', 10, 'Kg', 20, 'Fruits', 'grapes fruits', 'approved'),
(193, 10, '2019-04-05 03:54:44', 'youtube-channel-art-size.png', '5ca702bc601a0.png', 'image/png', 73944, 'Flower', 0, 'Kg', 0, 'Vegitables', 'ajhdjwdsq', 'disapproved');

-- --------------------------------------------------------

--
-- Table structure for table `admin_users`
--

CREATE TABLE `admin_users` (
  `id` int(11) NOT NULL,
  `username` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin_users`
--

INSERT INTO `admin_users` (`id`, `username`, `password`) VALUES
(1, 'admin', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `cart`
--

CREATE TABLE `cart` (
  `id` int(10) NOT NULL,
  `product_id` int(10) NOT NULL,
  `farmer_id` int(10) NOT NULL,
  `ip_add` varchar(250) NOT NULL,
  `user_id` varchar(255) DEFAULT NULL,
  `product_title` varchar(100) NOT NULL,
  `product_image` varchar(100) NOT NULL,
  `qty` int(10) NOT NULL,
  `units` varchar(10) NOT NULL,
  `price` int(100) NOT NULL,
  `total_amount` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cart`
--

INSERT INTO `cart` (`id`, `product_id`, `farmer_id`, `ip_add`, `user_id`, `product_title`, `product_image`, `qty`, `units`, `price`, `total_amount`) VALUES
(35, 110, 16, '-1', '120', 'Mango', 'mango.jpg', 1, 'Kg', 25, 25),
(37, 126, 10, '-1', '126', 'Tomato', 'tomato.jpg', 1, 'Kg', 45, 45),
(43, 162, 18, '-1', '129', 'PineApple', 'pineapple.jpeg', 1, 'Kg', 30, 30),
(44, 110, 16, '-1', '132', 'Mango', 'mango.jpg', 1, 'Kg', 25, 25),
(48, 108, 16, '-1', '128', 'Flower', 'flower.jpg', 1, 'Kg', 20, 20),
(49, 110, 16, '-1', '128', 'Mango', 'mango.jpg', 1, 'Kg', 25, 25),
(50, 112, 16, '-1', '128', 'Orange', 'orange.jpg', 1, 'Kg', 35, 35),
(51, 158, 18, '-1', '128', 'Millet', 'millet.jpg', 1, 'Ton', 12, 12),
(52, 137, 17, '-1', '128', 'Chickoo', 'chickoo.jpeg', 1, 'Kg', 55, 55),
(53, 165, 18, '-1', '128', 'Rice', 'rice.jpg', 1, 'Ton', 13, 13),
(55, 108, 16, '-1', '1484485675028650', 'Flower', 'flower.jpg', 1, 'Kg', 20, 20),
(56, 112, 16, '-1', '1484485675028650', 'Orange', 'orange.jpg', 1, 'Kg', 35, 35),
(57, 149, 17, '-1', '113', 'Jaweri', 'jawari.jpg', 1, 'Ton', 10, 10),
(58, 108, 16, '-1', '113', 'Flower', 'flower.jpg', 1, 'Kg', 20, 20),
(59, 110, 16, '-1', '113', 'Mango', 'mango.jpg', 1, 'Kg', 25, 25);

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `cat_id` varchar(100) NOT NULL,
  `cat_title` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`cat_id`, `cat_title`) VALUES
('Fruits', 'Fruits'),
('Grains', 'Grains'),
('Vegitables', 'Vegetables');

-- --------------------------------------------------------

--
-- Table structure for table `farmers`
--

CREATE TABLE `farmers` (
  `farmer_id` int(30) NOT NULL,
  `f_name` varchar(100) NOT NULL,
  `email` varchar(500) NOT NULL,
  `mobile` varchar(10) NOT NULL,
  `gender` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `certificate` varchar(100) NOT NULL,
  `user_activation_code` varchar(250) NOT NULL,
  `user_email_status` enum('not verified','verified') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `farmers`
--

INSERT INTO `farmers` (`farmer_id`, `f_name`, `email`, `mobile`, `gender`, `password`, `certificate`, `user_activation_code`, `user_email_status`) VALUES
(10, 'rahul', 'r@gmail.com', '9955212345', 'Male', 'rrr', 'Other Organic Certificate', '', 'verified'),
(16, 'pranit', 'p@gmail.com', '9933112209', 'Male', 'ppp', 'Other Organic Certificate', '', 'verified'),
(17, 'subodh', 'sh@gmail.com', '9966550044', 'male', 'shsh', 'Other Organic Certificate', '', 'verified'),
(18, 'Nilesh', 'n@gmail.com', '8695421357', 'male', 'nnn', 'PGS India Organic', '', 'verified'),
(19, 'subodh', 'subodhkhobrekar@gmail.com', '8692046686', 'Male', '123456', 'Self Declared Farmer', '', 'verified'),
(22, 'kunal', 'kunalbund1996@gmail.com', '9761428315', 'Male', '123456', 'Self Declared Farmer', 'c35e8dbc24c6df89f1ce4a1f59894e0b', 'not verified'),
(23, 'Rakesh', 'rakeshsharma.rs431@gmail.com', '8779398225', 'Male', '123456', 'Self Declared Farmer', '3ec2d9198f190fe3f992be5be5b0ec54', 'not verified'),
(25, 'Pranit Kadlag', 'pranitkadlag3@gmail.com', '9920355221', 'Male', '123456', 'Self Declared Farmer', 'b36cecf62473b7b4b95e445f86633613', 'verified');

-- --------------------------------------------------------

--
-- Table structure for table `fbusers`
--

CREATE TABLE `fbusers` (
  `user_id` int(11) NOT NULL,
  `oauth_pro` varchar(50) NOT NULL,
  `oauthid` varchar(100) NOT NULL,
  `f_name` varchar(100) NOT NULL,
  `l_name` varchar(100) NOT NULL,
  `email_id` varchar(100) NOT NULL,
  `gender` varchar(20) NOT NULL,
  `picture` varchar(255) NOT NULL,
  `url` text NOT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `fbusers`
--

INSERT INTO `fbusers` (`user_id`, `oauth_pro`, `oauthid`, `f_name`, `l_name`, `email_id`, `gender`, `picture`, `url`, `created_date`) VALUES
(6, 'facebook', '101416637505154', 'Sharon', 'Chengman', 'qgjiriwwzw_1538471912@tfbnw.net', '', 'https://platform-lookaside.fbsbx.com/platform/profilepic/?asid=101416637505154&height=200&width=200&ext=1548781126&hash=AeQ6Be0OU6sBBPQM', '', '2018-12-30 22:28:46'),
(7, 'facebook', '112533266388777', 'Rick', 'Okelolaberg', 'diecltyjzo_1538471908@tfbnw.net', '', 'https://platform-lookaside.fbsbx.com/platform/profilepic/?asid=112533266388777&height=200&width=200&ext=1548781243&hash=AeQpHo8UFlPWX7JQ', '', '2018-12-30 22:30:44'),
(10, 'facebook', '146147099690276', 'Open', 'User', 'open_cdbtuqt_user@tfbnw.net', '', 'https://platform-lookaside.fbsbx.com/platform/profilepic/?asid=146147099690276&height=200&width=200&ext=1548933978&hash=AeSCdE-DNHQ163GZ', '', '2019-01-01 16:45:04'),
(20, 'facebook', '1484485675028650', 'Subodh', 'Khobrekar', '', 'male', 'https://platform-lookaside.fbsbx.com/platform/profilepic/?asid=1484485675028650&height=50&width=50&ext=1556625885&hash=AeT8L-RXiUNXDEWh', 'https://www.facebook.com/app_scoped_user_id/YXNpZADpBWEhKNm9CNnFFTXp0TExtWnduTWhiYldqNV9ycHRjbnRmaW42MERCdnVjNm5Yc3hEcnZA2TmloTUFzTTJsX0VVeS1ObVkzbFZAtbTRxV1p4Mk1DYzhyc19Sd0k2MW43OWh1UE1QVEx2ZAnQxXzktYkJD/', '2019-01-03 15:20:01');

-- --------------------------------------------------------

--
-- Table structure for table `gusers`
--

CREATE TABLE `gusers` (
  `id` int(11) NOT NULL,
  `oauth_provider` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `oauth_uid` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `first_name` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `last_name` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `gender` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `locale` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `picture` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `link` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `gusers`
--

INSERT INTO `gusers` (`id`, `oauth_provider`, `oauth_uid`, `first_name`, `last_name`, `email`, `gender`, `locale`, `picture`, `link`, `created`, `modified`) VALUES
(7, 'google', '106665858354542724013', 'Organic Project', 'apsit', 'apsitproject@gmail.com', '', 'en', 'https://lh5.googleusercontent.com/-yj_R2RBTsHM/AAAAAAAAAAI/AAAAAAAAAAA/ACHi3rdjrtBkgP9lx05xh8Dz-oJo_2HOqw/mo/photo.jpg', '', '2019-01-03 10:46:14', '2019-03-20 06:38:02'),
(8, 'google', '101321747183698674671', 'subodh', 'khobrekar', 'subodhkhobrekar@gmail.com', '', 'en', 'https://lh3.googleusercontent.com/-nOLByUMb-Os/AAAAAAAAAAI/AAAAAAAAANY/DPPHEFIziZo/photo.jpg', 'https://plus.google.com/101321747183698674671', '2019-03-16 17:51:04', '2019-03-17 09:09:02');

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `order_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `farmer_id` int(100) NOT NULL,
  `product_id` int(11) NOT NULL,
  `product_title` varchar(100) NOT NULL,
  `product_image` varchar(500) NOT NULL,
  `qty` int(11) NOT NULL,
  `units` varchar(100) NOT NULL,
  `total_amount` int(100) NOT NULL,
  `trx_id` varchar(255) NOT NULL,
  `p_status` varchar(20) NOT NULL,
  `date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`order_id`, `user_id`, `farmer_id`, `product_id`, `product_title`, `product_image`, `qty`, `units`, `total_amount`, `trx_id`, `p_status`, `date`) VALUES
(40, 113, 16, 112, 'Orange', 'orange.jpg', 1, 'Kg', 35, '7JP202447G718371K', 'Completed', '2019-03-31 18:37:00'),
(41, 113, 16, 110, 'Mango', 'mango.jpg', 1, 'Kg', 25, '7JP202447G718371K', 'Completed', '2019-03-31 18:37:00'),
(42, 113, 16, 108, 'Flower', 'flower.jpg', 1, 'Kg', 20, '2B626739PU821363X', 'Completed', '2019-03-31 18:40:45'),
(43, 134, 16, 108, 'Flower', 'flower.jpg', 1, 'Kg', 20, '3B99395051451373J', 'Completed', '2019-04-02 20:30:30'),
(44, 134, 16, 110, 'Mango', 'mango.jpg', 1, 'Kg', 25, '3B99395051451373J', 'Completed', '2019-04-02 20:30:30'),
(45, 134, 17, 137, 'Chickoo', 'chickoo.jpeg', 1, 'Kg', 55, '3B99395051451373J', 'Completed', '2019-04-02 20:30:30'),
(46, 134, 16, 110, 'Mango', 'mango.jpg', 1, 'Kg', 25, '0BU94767JE674470V', 'Completed', '2019-04-02 20:35:39'),
(47, 134, 16, 112, 'Orange', 'orange.jpg', 1, 'Kg', 35, '0BU94767JE674470V', 'Completed', '2019-04-02 20:35:40'),
(48, 134, 16, 112, 'Orange', 'orange.jpg', 1, 'Kg', 35, '4RV177312N820150B', 'Completed', '2019-04-02 20:50:41'),
(49, 113, 16, 112, 'Orange', 'orange.jpg', 1, 'Kg', 35, '9N346427CB639860X', 'Completed', '2019-04-02 21:07:18'),
(50, 113, 16, 110, 'Mango', 'mango.jpg', 1, 'Kg', 25, '9N346427CB639860X', 'Completed', '2019-04-02 21:07:18'),
(51, 113, 16, 112, 'Orange', 'orange.jpg', 1, 'Kg', 35, '4UM44226KV520030V', 'Completed', '2019-04-02 21:12:03'),
(52, 113, 16, 110, 'Mango', 'mango.jpg', 1, 'Kg', 25, '6AT84663LG321671A', 'Pending', '2019-04-02 21:19:01'),
(53, 113, 16, 108, 'Flower', 'flower.jpg', 1, 'Kg', 20, '6A656401F58202814', 'Pending', '2019-04-02 21:28:28'),
(54, 113, 10, 124, 'Potato', 'potato.jpg', 1, 'Kg', 10, '8UF382974M096850D', 'Completed', '2019-04-02 21:47:33'),
(55, 113, 16, 112, 'Orange', 'orange.jpg', 1, 'Kg', 35, '7RP2311674164700P', 'Completed', '2019-04-02 21:54:55'),
(56, 113, 16, 112, 'Orange', 'orange.jpg', 1, 'Kg', 35, '4N617123RB853012S', 'Completed', '2019-04-02 21:57:33'),
(57, 113, 16, 110, 'Mango', 'mango.jpg', 1, 'Kg', 25, '0A192092YN419472F', 'Completed', '2019-04-03 07:17:14'),
(58, 113, 16, 110, 'Mango', 'mango.jpg', 1, 'Kg', 25, '24D87969583374122', 'Completed', '2019-04-03 10:20:12'),
(59, 113, 16, 112, 'Orange', 'orange.jpg', 1, 'Kg', 35, '24D87969583374122', 'Completed', '2019-04-03 10:20:12'),
(60, 113, 16, 112, 'Orange', 'orange.jpg', 1, 'Kg', 35, '9MY37958NH803233T', 'Completed', '2019-04-03 17:49:17');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `product_id` int(100) NOT NULL,
  `product_cat` int(100) NOT NULL,
  `product_title` varchar(255) NOT NULL,
  `product_price` int(100) NOT NULL,
  `product_desc` text NOT NULL,
  `product_image` text NOT NULL,
  `product_keywords` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`product_id`, `product_cat`, `product_title`, `product_price`, `product_desc`, `product_image`, `product_keywords`) VALUES
(1, 2, 'Apple', 5000, 'pure fresh apples', 'apple.jpg', 'ap apples app fruits'),
(2, 2, 'Oraange', 25000, 'pure natural orange', 'orange.jpg', 'fruits oran orange'),
(3, 1, 'Potato', 60, 'pure organic potato', 'potato.jpg', 'pure potato vegitables organic'),
(4, 2, 'mango', 40, 'mangos pure fruits', 'mango.jpg', 'fruits mango'),
(5, 1, 'Onion', 30, 'onion vegitales', 'onion.png', 'vegitables onion'),
(6, 1, 'Flower', 50, 'Flower', 'flower.jpg', 'vegitables flower');

-- --------------------------------------------------------

--
-- Table structure for table `recommendation`
--

CREATE TABLE `recommendation` (
  `id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `rating` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `recommendation`
--

INSERT INTO `recommendation` (`id`, `product_id`, `rating`) VALUES
(1, 124, '1.0'),
(2, 128, '1.0'),
(3, 130, '3.0'),
(4, 137, '3.6666666666666665'),
(5, 145, '2.0'),
(6, 147, '3.0'),
(7, 156, '5.0'),
(8, 171, '4.0');

-- --------------------------------------------------------

--
-- Table structure for table `review`
--

CREATE TABLE `review` (
  `rating_id` int(11) NOT NULL,
  `user_id` int(255) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL,
  `rating` varchar(255) DEFAULT NULL,
  `review` varchar(255) DEFAULT NULL,
  `review_timestamp` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `review`
--

INSERT INTO `review` (`rating_id`, `user_id`, `product_id`, `rating`, `review`, `review_timestamp`) VALUES
(1, 132, 128, '1', 'Very Bitter', '2019-03-20 16:58:16'),
(2, 132, 130, '3', 'good', '0000-00-00 00:00:00'),
(3, 132, 137, '5', NULL, '0000-00-00 00:00:00'),
(4, 133, 145, '2', NULL, '0000-00-00 00:00:00'),
(5, 133, 156, '5', NULL, '0000-00-00 00:00:00'),
(6, 133, 137, '2', NULL, '0000-00-00 00:00:00'),
(7, 126, 137, '4', NULL, '0000-00-00 00:00:00'),
(8, 126, 124, '1', NULL, '0000-00-00 00:00:00'),
(9, 126, 147, '3', NULL, '0000-00-00 00:00:00'),
(10, 132, 171, '4', NULL, '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `subscription`
--

CREATE TABLE `subscription` (
  `id` int(11) NOT NULL,
  `email` varchar(50) NOT NULL,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `subscription`
--

INSERT INTO `subscription` (`id`, `email`, `date`) VALUES
(1, 'apsitproject@gmail.com', '2019-02-16 11:57:19'),
(2, 'r@gmail.com', '2019-03-29 05:55:27');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int(255) UNSIGNED NOT NULL,
  `oauth_provider` varchar(255) NOT NULL,
  `oauth_uid` varchar(255) NOT NULL,
  `first_name` varchar(100) NOT NULL,
  `last_name` varchar(100) NOT NULL,
  `name` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `mobile` varchar(10) NOT NULL,
  `gender` varchar(300) NOT NULL,
  `user_activation_code` varchar(250) NOT NULL,
  `user_email_status` enum('not verified','verified') NOT NULL,
  `dob` varchar(10) NOT NULL,
  `locale` varchar(10) NOT NULL,
  `picture` varchar(255) NOT NULL,
  `link` varchar(255) NOT NULL,
  `address` varchar(500) NOT NULL,
  `city` varchar(20) NOT NULL,
  `state` varchar(20) NOT NULL DEFAULT 'Maharashtra',
  `pincode` int(11) NOT NULL,
  `password` varchar(50) NOT NULL,
  `created` datetime NOT NULL,
  `modified` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `oauth_provider`, `oauth_uid`, `first_name`, `last_name`, `name`, `email`, `mobile`, `gender`, `user_activation_code`, `user_email_status`, `dob`, `locale`, `picture`, `link`, `address`, `city`, `state`, `pincode`, `password`, `created`, `modified`) VALUES
(113, '', '', 'kunal', '', 'kunal', 'k@gmail.com', '9761428315', 'Male', '', 'verified', '1995-05-21', '', '', '', 'ghatkopar', 'mumbai', 'maharashtra', 400085, '123456', '0000-00-00 00:00:00', '2019-03-14 18:59:50'),
(118, 'facebook', '1484485675028650', 'Subodh', 'Khobrekar', '', '', '', 'male', '', 'verified', '', '', 'https://platform-lookaside.fbsbx.com/platform/profilepic/?asid=1484485675028650&height=50&width=50&ext=1556625885&hash=AeT8L-RXiUNXDEWh', 'https://www.facebook.com/app_scoped_user_id/YXNpZADpBWEhKNm9CNnFFTXp0TExtWnduTWhiYldqNV9ycHRjbnRmaW42MERCdnVjNm5Yc3hEcnZA2TmloTUFzTTJsX0VVeS1ObVkzbFZAtbTRxV1p4Mk1DYzhyc19Sd0k2MW43OWh1UE1QVEx2ZAnQxXzktYkJD/', '', '', 'Maharashtra', 0, '', '2019-02-19 18:12:19', '2019-03-31 14:04:46'),
(122, '', '', 'subodh', '', 'Subodh', 'subodhkhobrekar@gmail.com', '8692046886', 'Male', '', 'verified', '', '', '', '', '', '', 'Maharashtra', 0, '123456', '2019-03-14 19:04:05', '2019-03-14 19:04:05'),
(125, '', '', 'satya', '', 'satya', 'yadavsatyajeet19@gmail.com', '9761428315', 'Male', '756c8e577561066fae20215c85231035', 'not verified', '', '', '', '', '', '', 'Maharashtra', 0, '123456', '2019-03-15 07:25:39', '2019-03-15 07:25:39'),
(126, '', '', 'Chinmay', '', 'Chinmay', 'ckarnik91@gmail.com', '9819757210', 'Male', '2a132c5bd6ddfc57359e4c2f01c10920', 'verified', '1997-10-15', '', '', '', '', 'dombivli', 'maharashtra', 0, '123456', '2019-03-15 07:28:20', '2019-03-15 07:32:56'),
(128, 'google', '106665858354542724013', 'Organic Project', 'apsit', '', 'apsitproject@gmail.com', '', '', '8cabbaa0ee2e04a385f9665398813f5c', 'not verified', '', 'en', 'https://lh5.googleusercontent.com/-yj_R2RBTsHM/AAAAAAAAAAI/AAAAAAAAAAA/ACHi3rdjrtBkgP9lx05xh8Dz-oJo_2HOqw/mo/photo.jpg', '', '', '', 'Maharashtra', 0, '', '2019-03-20 06:37:24', '2019-03-20 06:37:24'),
(129, '', '', 'Amit Prajapati', '', '', 'amitgprajapati1998@gmail.com', '9923874104', 'Male', 'f7dca503575b033265893383b76a099a', 'verified', '', '', '', '', '', '', 'Maharashtra', 0, '123456', '2019-03-20 05:03:53', '2019-03-20 05:03:53'),
(131, '', '', 'Sunil Sushir', '', '', 'sasushir@apsit.edu.in', '9860937043', 'Male', '2d8619ebfcdc0002c6431df06d5f6647', 'not verified', '', '', '', '', '', '', 'Maharashtra', 0, '123456', '2019-03-20 07:41:18', '2019-03-20 07:41:18'),
(132, '', '', 'Sunil Sushir', '', '', 'sasushir@gmail.com', '9761428315', 'Male', '10a05e3e23bd446b06213d17db49c5bb', 'verified', '', '', '', '', '', '', 'Maharashtra', 0, '123456', '2019-03-20 07:48:32', '2019-03-20 07:48:32'),
(133, '', '', 'Pranit ', '', '', 'pranitkadlag3@gmail.com', '7039137973', 'Male', '67168e494d89adc8b18b055d75ef85c5', 'not verified', '', '', '', '', '', '', 'Maharashtra', 0, '123456', '2019-03-28 16:48:41', '2019-03-28 16:48:41'),
(134, '', '', 'kunal band', '', '', 'kunalbund1996@gmail.com', '9820761848', 'Male', '439b4ff0d8c590f0a56dc9a9bcc82028', 'verified', '', '', '', '', '', '', 'Maharashtra', 0, 'kunal@1996', '2019-03-29 06:12:11', '2019-03-29 06:12:11'),
(135, 'google', '105144657018546626263', 'Rahul', 'Vishwakarma', '', 'rahul.v3160@gmail.com', '', '', '67424e214309b1b820bac924c4716059', 'verified', '', 'en', 'https://lh3.googleusercontent.com/-h8TFN1OnO2M/AAAAAAAAAAI/AAAAAAAAAAA/ACHi3rcNvFRMChOSGRF7H-x896nilCUsKw/mo/photo.jpg', '', '', '', 'Maharashtra', 0, '', '2019-03-29 07:23:04', '2019-03-29 07:23:04'),
(136, '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', 'Maharashtra', 0, '123456', '2019-04-05 09:04:27', '2019-04-05 09:04:27'),
(137, '', '', 'pranit', '', '', 'pranitkadlag4@gmail.com', '7039137973', 'Male', '78400a6109f71c576ab17b29a023574c', 'not verified', '', '', '', '', '', '', 'Maharashtra', 0, '123456', '2019-04-05 09:05:21', '2019-04-05 09:05:21'),
(138, '', '', 'Kiran Deshpande', '', '', 'kbdeshpande@apsit.edu.in', '9158452105', 'Male', '8e27ccdbac7ce9f78fc5e5869b5fee7d', 'not verified', '', '', '', '', '', '', 'Maharashtra', 0, '12345678', '2019-04-05 09:14:54', '2019-04-05 09:14:54'),
(139, 'google', '104303603116086978572', 'Prof. K.B.', 'Deshpande', '', 'kbdeshpande@apsit.edu.in', '', '', 'c6164ecc8979d5cc719159f8e03850ff', 'not verified', '', 'en', 'https://lh4.googleusercontent.com/-CEvYUN1rVjU/AAAAAAAAAAI/AAAAAAAAAMI/B3xNhc_3XXE/photo.jpg', '', '', '', 'Maharashtra', 0, '', '2019-04-05 09:20:06', '2019-04-05 09:20:06');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `addproduct`
--
ALTER TABLE `addproduct`
  ADD PRIMARY KEY (`product_id`),
  ADD KEY `farmer_id` (`farmer_id`);

--
-- Indexes for table `admin_users`
--
ALTER TABLE `admin_users`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `cart`
--
ALTER TABLE `cart`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`cat_id`);

--
-- Indexes for table `farmers`
--
ALTER TABLE `farmers`
  ADD PRIMARY KEY (`farmer_id`);

--
-- Indexes for table `fbusers`
--
ALTER TABLE `fbusers`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexes for table `gusers`
--
ALTER TABLE `gusers`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`order_id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`product_id`);

--
-- Indexes for table `recommendation`
--
ALTER TABLE `recommendation`
  ADD PRIMARY KEY (`id`),
  ADD KEY `foreignkey` (`product_id`) USING BTREE;

--
-- Indexes for table `review`
--
ALTER TABLE `review`
  ADD PRIMARY KEY (`rating_id`),
  ADD KEY `product_id` (`product_id`);

--
-- Indexes for table `subscription`
--
ALTER TABLE `subscription`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `addproduct`
--
ALTER TABLE `addproduct`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=194;

--
-- AUTO_INCREMENT for table `admin_users`
--
ALTER TABLE `admin_users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `cart`
--
ALTER TABLE `cart`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=60;

--
-- AUTO_INCREMENT for table `farmers`
--
ALTER TABLE `farmers`
  MODIFY `farmer_id` int(30) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT for table `fbusers`
--
ALTER TABLE `fbusers`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `gusers`
--
ALTER TABLE `gusers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `orders`
--
ALTER TABLE `orders`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `product_id` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `recommendation`
--
ALTER TABLE `recommendation`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `review`
--
ALTER TABLE `review`
  MODIFY `rating_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `subscription`
--
ALTER TABLE `subscription`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(255) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=140;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
