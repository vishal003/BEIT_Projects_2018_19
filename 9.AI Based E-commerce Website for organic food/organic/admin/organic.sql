-- phpMyAdmin SQL Dump
-- version 4.4.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Feb 20, 2019 at 06:23 AM
-- Server version: 5.6.26
-- PHP Version: 5.6.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
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

CREATE TABLE IF NOT EXISTS `addproduct` (
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
) ENGINE=InnoDB AUTO_INCREMENT=172 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `addproduct`
--

INSERT INTO `addproduct` (`product_id`, `farmer_id`, `date`, `product_image`, `newname`, `file_type`, `file_size`, `product_title`, `quantity`, `units`, `product_price`, `product_cat`, `product_desc`, `status`) VALUES
(108, 16, '2019-02-17 10:12:08', 'flower.jpg', '5c5980461ca6e.jpg', 'image/jpeg', 1042995, 'Flower', 10, 'Kg', 20, 'Vegitables', 'flower vegitables', 'approved'),
(110, 16, '2019-02-17 11:04:07', 'mango.jpg', '5c5980a081923.jpg', 'image/jpeg', 6890, 'Mango', 20, 'Kg', 25, 'Fruits', 'mango fruits', 'disapproved'),
(112, 16, '2019-02-17 10:03:11', 'orange.jpg', '5c5980d5a654c.jpg', 'image/jpeg', 8527, 'Orange', 30, 'Kg', 35, 'Fruits', 'fruits orange', 'approved'),
(114, 16, '2019-02-17 10:03:12', 'onion.png', '5c598112d0bf8.png', 'image/png', 62398, 'Onion', 40, 'Kg', 20, 'Vegitables', 'vegitables onions', 'approved'),
(124, 10, '2019-02-17 10:03:14', 'potato.jpg', '5c5985793b8fc.jpg', 'image/jpeg', 4356, 'Potato', 50, 'Kg', 10, 'Vegitables', 'vegitables potato', 'approved'),
(126, 10, '2019-02-17 10:03:19', 'tomato.jpg', '5c5985b664742.jpg', 'image/jpeg', 7415, 'Tomato', 30, 'Kg', 45, 'Vegitables', 'vegitables tomato', 'approved'),
(128, 10, '2019-02-17 10:10:53', 'bittergoud.jpg', '5c598719387d8.jpg', 'image/jpeg', 9084, 'Bittergoud', 10, 'Kg', 24, 'Vegitables', 'bittergoud vegitables', 'approved'),
(130, 10, '2019-02-17 10:10:56', 'brinjal.jpeg', '5c5987648d6b5.jpeg', 'image/jpeg', 6851, 'Brinjal', 25, 'Kg', 13, 'Vegitables', 'brinjal vegitables', 'approved'),
(134, 10, '2019-02-17 10:03:24', 'carrot.jpeg', '5c59883b43785.jpeg', 'image/jpeg', 9441, 'Carrot', 50, 'Kg', 40, 'Vegitables', 'vegitales carrot', 'approved'),
(137, 17, '2019-02-17 10:11:02', 'chickoo.jpeg', '5c5988d37b953.jpeg', 'image/jpeg', 4916, 'Chickoo', 24, 'Kg', 55, 'Fruits', 'chickoo fruits', 'approved'),
(145, 17, '2019-02-17 10:11:06', 'greenpeas.jpg', '5c598a0a4882f.jpg', 'image/jpeg', 5582, 'Greenpeas', 18, 'Kg', 65, 'Vegitables', 'greenpeas vegitables', 'approved'),
(147, 17, '2019-02-17 10:11:10', 'jamun.jpg', '5c598a45693c1.jpg', 'image/jpeg', 22105, 'Jamun', 5, 'Kg', 15, 'Fruits', 'jamun fruitd', 'approved'),
(149, 17, '2019-02-17 10:11:14', 'jawari.jpg', '5c598aba8f59f.jpg', 'image/jpeg', 8225, 'Jaweri', 50, 'Ton', 10, 'Grains', 'jawari grains', 'approved'),
(156, 18, '2019-02-17 10:11:18', 'lemon.jpeg', '5c598c498ec48.jpeg', 'image/jpeg', 6911, 'Lemon', 10, 'Kg', 26, 'Vegitables', 'vegitables lemon', 'approved'),
(158, 18, '2019-02-17 09:57:05', 'millet.jpg', '5c598c9156b7d.jpg', 'image/jpeg', 18384, 'Millet', 30, 'Ton', 12, 'Grains', 'grains millet', 'approved'),
(162, 18, '2019-02-17 10:43:12', 'pineapple.jpeg', '5c598cea8f9f0.jpeg', 'image/jpeg', 7062, 'PineApple', 30, 'Kg', 30, 'Fruits', 'pineapple fruits', 'disapproved'),
(165, 18, '2019-02-17 10:11:28', 'rice.jpg', '5c598d5085575.jpg', 'image/jpeg', 5331, 'Rice', 45, 'Ton', 13, 'select category', 'rice grains', 'approved'),
(167, 18, '2019-02-17 10:11:31', 'strawberry.jpg', '5c598d8e05bd5.jpg', 'image/jpeg', 17235, 'StrawBerry', 10, 'Grams', 22, 'Fruits', 'strawerry fruits', 'approved'),
(171, 18, '2019-02-17 11:52:39', 'watermelon.jpg', '5c598e2bdb42e.jpg', 'image/jpeg', 6595, 'WaterMelon', 23, 'select category', 40, 'Fruits', 'watermelon fruits', 'disapproved');

-- --------------------------------------------------------

--
-- Table structure for table `cart`
--

CREATE TABLE IF NOT EXISTS `cart` (
  `id` int(10) NOT NULL,
  `product_id` int(10) NOT NULL,
  `farmer_id` int(10) NOT NULL,
  `ip_add` varchar(250) NOT NULL,
  `user_id` int(10) DEFAULT NULL,
  `product_title` varchar(100) NOT NULL,
  `product_image` varchar(100) NOT NULL,
  `qty` int(10) NOT NULL,
  `units` varchar(10) NOT NULL,
  `price` int(100) NOT NULL,
  `total_amount` int(100) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cart`
--

INSERT INTO `cart` (`id`, `product_id`, `farmer_id`, `ip_add`, `user_id`, `product_title`, `product_image`, `qty`, `units`, `price`, `total_amount`) VALUES
(4, 100, 16, '-1', 113, 'Banana', 'banana.jpeg', 1, 'Kg', 30, 30),
(5, 110, 16, '-1', 113, 'Mango', 'mango.jpg', 1, 'Kg', 25, 25),
(6, 108, 16, '-1', 113, 'Flower', 'flower.jpg', 1, 'Kg', 20, 20),
(7, 114, 16, '-1', 113, 'Onion', 'onion.png', 1, 'Kg', 20, 20);

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE IF NOT EXISTS `categories` (
  `cat_id` varchar(100) NOT NULL,
  `cat_title` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`cat_id`, `cat_title`) VALUES
('Fruits', 'Fruits'),
('Grains', 'Grains'),
('Vegitables', 'Vegitables');

-- --------------------------------------------------------

--
-- Table structure for table `farmers`
--

CREATE TABLE IF NOT EXISTS `farmers` (
  `farmer_id` int(30) NOT NULL,
  `f_name` varchar(100) NOT NULL,
  `email` varchar(500) NOT NULL,
  `mobile` varchar(10) NOT NULL,
  `gender` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `certificate` varchar(100) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `farmers`
--

INSERT INTO `farmers` (`farmer_id`, `f_name`, `email`, `mobile`, `gender`, `password`, `certificate`) VALUES
(10, 'rahul', 'r@gmail.com', '9955330033', 'Male', 'rrr', 'Other Organic Certificate'),
(16, 'pranit', 'p@gmail.com', '9933112209', 'Male', 'ppp', 'Other Organic Certificate'),
(17, 'subodh', 'sh@gmail.com', '9966550044', 'male', 'shsh', 'Other Organic Certificate'),
(18, 'Nilesh', 'n@gmail.com', '8695421357', 'male', 'nnn', 'PGS India Organic');

-- --------------------------------------------------------

--
-- Table structure for table `fbusers`
--

CREATE TABLE IF NOT EXISTS `fbusers` (
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
) ENGINE=MyISAM AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `fbusers`
--

INSERT INTO `fbusers` (`user_id`, `oauth_pro`, `oauthid`, `f_name`, `l_name`, `email_id`, `gender`, `picture`, `url`, `created_date`) VALUES
(6, 'facebook', '101416637505154', 'Sharon', 'Chengman', 'qgjiriwwzw_1538471912@tfbnw.net', '', 'https://platform-lookaside.fbsbx.com/platform/profilepic/?asid=101416637505154&height=200&width=200&ext=1548781126&hash=AeQ6Be0OU6sBBPQM', '', '2018-12-30 22:28:46'),
(7, 'facebook', '112533266388777', 'Rick', 'Okelolaberg', 'diecltyjzo_1538471908@tfbnw.net', '', 'https://platform-lookaside.fbsbx.com/platform/profilepic/?asid=112533266388777&height=200&width=200&ext=1548781243&hash=AeQpHo8UFlPWX7JQ', '', '2018-12-30 22:30:44'),
(10, 'facebook', '146147099690276', 'Open', 'User', 'open_cdbtuqt_user@tfbnw.net', '', 'https://platform-lookaside.fbsbx.com/platform/profilepic/?asid=146147099690276&height=200&width=200&ext=1548933978&hash=AeSCdE-DNHQ163GZ', '', '2019-01-01 16:45:04'),
(20, 'facebook', '1484485675028650', 'Subodh', 'Khobrekar', '', 'male', 'https://platform-lookaside.fbsbx.com/platform/profilepic/?asid=1484485675028650&height=50&width=50&ext=1552927928&hash=AeRS9bDouxj0mdRy', 'https://www.facebook.com/app_scoped_user_id/YXNpZADpBWEdqOGlKTi1fNkVRUlZA2RmRYeGxJM0trSTNGWllLLWNoYjJuZAHRTNEZANTE16R2VlTnFqTDdJMFU2WUlseTE1UVIzQ3JMMG5lRnlaNkk4YWt3eDhwcUpWY0FmeW9KeXpiVjhxbTBLU0NydXo1ZAVcy/', '2019-01-03 15:20:01');

-- --------------------------------------------------------

--
-- Table structure for table `gusers`
--

CREATE TABLE IF NOT EXISTS `gusers` (
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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `gusers`
--

INSERT INTO `gusers` (`id`, `oauth_provider`, `oauth_uid`, `first_name`, `last_name`, `email`, `gender`, `locale`, `picture`, `link`, `created`, `modified`) VALUES
(7, 'google', '106665858354542724013', 'Organic Project', 'apsit', 'apsitproject@gmail.com', '', 'en', 'https://lh5.googleusercontent.com/-yj_R2RBTsHM/AAAAAAAAAAI/AAAAAAAAAAA/ACevoQNKBnNVHmR99-b6Qp6bGuIMGrcrSA/mo/photo.jpg', '', '2019-01-03 10:46:14', '2019-02-17 08:42:01');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE IF NOT EXISTS `products` (
  `product_id` int(100) NOT NULL,
  `product_cat` int(100) NOT NULL,
  `product_title` varchar(255) NOT NULL,
  `product_price` int(100) NOT NULL,
  `product_desc` text NOT NULL,
  `product_image` text NOT NULL,
  `product_keywords` text NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

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
-- Table structure for table `subscription`
--

CREATE TABLE IF NOT EXISTS `subscription` (
  `id` int(11) NOT NULL,
  `email` varchar(50) NOT NULL,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `subscription`
--

INSERT INTO `subscription` (`id`, `email`, `date`) VALUES
(1, 'kunalbund1996@gmail.com', '2019-02-16 11:57:19'),
(3, 'y@gmail.com', '2019-02-17 07:37:05'),
(4, 'kunalbund1996@gmail.com', '2019-02-17 08:27:12');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `user_id` int(100) NOT NULL,
  `name` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `mobile` varchar(10) NOT NULL,
  `gender` varchar(300) NOT NULL,
  `dob` varchar(10) NOT NULL,
  `address` varchar(500) NOT NULL,
  `city` varchar(20) NOT NULL,
  `state` varchar(20) NOT NULL DEFAULT 'Maharashtra',
  `pincode` int(11) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=206 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `name`, `email`, `mobile`, `gender`, `dob`, `address`, `city`, `state`, `pincode`, `password`) VALUES
(113, 'kunal', 'k@gmail.com', '9920355221', 'Male', '1995-05-21', '10,hariyali village,ganesh marg,vikhroli', 'mumbai', 'maharashtra', 400083, 'kkk'),
(114, 'sunil', 'su@gmail.com', '9437898765', 'Male', '', '', '', 'Maharashtra', 0, 'sss'),
(198, 'Subodh', '', '', 'male', '', '', '', 'Maharashtra', 0, ''),
(199, 'Organic Project', 'apsitproject@gmail.com', '', '', '', '', '', 'Maharashtra', 0, ''),
(200, '', '', '', '', '', '', '', 'Maharashtra', 0, ''),
(201, '', '', '', '', '', '', '', 'Maharashtra', 0, ''),
(202, '', '', '', '', '', '', '', 'Maharashtra', 0, ''),
(203, '', '', '', '', '', '', '', 'Maharashtra', 0, ''),
(204, '', '', '', '', '', '', '', 'Maharashtra', 0, ''),
(205, '', '', '', '', '', '', '', 'Maharashtra', 0, '');

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
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`product_id`);

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
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=172;
--
-- AUTO_INCREMENT for table `cart`
--
ALTER TABLE `cart`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `farmers`
--
ALTER TABLE `farmers`
  MODIFY `farmer_id` int(30) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=19;
--
-- AUTO_INCREMENT for table `fbusers`
--
ALTER TABLE `fbusers`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=21;
--
-- AUTO_INCREMENT for table `gusers`
--
ALTER TABLE `gusers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `product_id` int(100) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `subscription`
--
ALTER TABLE `subscription`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(100) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=206;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `addproduct`
--
ALTER TABLE `addproduct`
  ADD CONSTRAINT `addproduct_ibfk_1` FOREIGN KEY (`farmer_id`) REFERENCES `farmers` (`farmer_id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
