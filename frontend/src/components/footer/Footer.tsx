const Footer = () => {
  return (
    <footer className="bg-inherit bottom-0">
      <div className="max-w-full mx-7">
        <div className="grid grid-cols-1 md:grid-cols-4 gap-8 py-12 border-b border-gray-700">
          {/* Logo and About */}
          <div>
            <h3 className="text-lg font-semibold mb-4">ShopQuik</h3>
            <p className="text-sm text-violet-900">
              Delivering quality food and innovative solutions <br /> for a
              better diet since 1936.
            </p>
          </div>

          {/* Links */}
          <div>
            <h3 className="text-lg font-semibold mb-4">Links</h3>
            <ul className="space-y-2 text-sm">
              <li>
                <a href="#" className="hover:text-blue-500">
                  Home
                </a>
              </li>
              <li>
                <a href="#" className="hover:text-blue-500">
                  About Us
                </a>
              </li>
              <li>
                <a href="#" className="hover:text-blue-500">
                  Services
                </a>
              </li>
              <li>
                <a href="#" className="hover:text-blue-500">
                  Contact
                </a>
              </li>
            </ul>
          </div>

          {/* Support */}
          <div>
            <h3 className="text-lg font-semibold mb-4">Support</h3>
            <ul className="space-y-2 text-sm">
              <li>
                <a href="#" className="hover:text-blue-500">
                  Help Center
                </a>
              </li>
              <li>
                <a href="#" className="hover:text-blue-500">
                  Privacy Policy
                </a>
              </li>
              <li>
                <a href="#" className="hover:text-blue-500">
                  Terms of Service
                </a>
              </li>
            </ul>
          </div>

          {/* Newsletter */}
          <div>
            <h3 className="text-lg font-semibold mb-4">Subscribe</h3>
            <p className="text-sm text-gray-600 mb-4">
              Join our newsletter to stay updated.
            </p>
            <form className="flex">
              <input
                type="email"
                className="w-full px-4 py-2 rounded-l-md border border-gray-600 bg-gray-700 text-sm text-white placeholder-gray-400 focus:ring-2 focus:ring-gray-500"
                placeholder="Enter your email!"
              />
              <button
                type="submit"
                className="bg-gradient-to-r from-purple-500 via-violet-500 to-pink-500 px-4 py-2 rounded-r-md text-sm font-medium hover:bg-emerald-700"
              >
                Subscribe
              </button>
            </form>
          </div>
        </div>

        {/* Footer Bottom */}
        <div className="flex justify-between items-center py-4 text-sm">
          <p>&copy; 2024 ShopQuik. All Rights Reserved.</p>
          <div className="space-x-2">
            <a href="#" className="hover:text-blue-500">
              Facebook
            </a>
            <a href="#" className="hover:text-blue-500">
              Twitter
            </a>
            <a href="#" className="hover:text-blue-500">
              Instagram
            </a>
            <a href="#" className="hover:text-blue-500">
              LinkedIn
            </a>
          </div>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
